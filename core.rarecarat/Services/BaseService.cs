using ARGIL.Core.Entities;
using ARGIL.Core.IModels;
using ARGIL.Core.IRepository;
using ARGIL.Core.IServices;
using ARGIL.Core.Models;
using ARGIL.Core.Utils;
using ARGIL.Core.Utils.Validators;
using ARGIL.Utils.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using ValidationResult = ARGIL.Utils.Entity.ValidationResult;

namespace ARGIL.Core
{
    public abstract class BaseService<TEntity, TCreate, TUpdate, TDetails, TListItem> : Loggable, IBaseService<TCreate, TUpdate, TDetails, TListItem>
        where TCreate : ICreateModel
        where TUpdate : IUpdateModel
        where TDetails : IDetailsModel
        where TListItem : IListItemModel
        where TEntity : IEntity
    {
        protected IUnitOfWork _unitOfWork;

        protected BaseService( IUnitOfWork unitOfWork, ILogger logger ) : base()
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        protected IRepository<TEntity> Repository
        {
            get
            {
                return _unitOfWork.Repository<TEntity>( DoGetRepositoryType() );
            }
        }

        public abstract Type DoGetRepositoryType();

        protected abstract object GetIdFrom( TUpdate update );

        #region Validation

        public virtual ValidationResult<object> ValidateBusinessRulesForCreate( TCreate model )
        {
            if ( IsNotSupportedOperation<TCreate>() )
                return ConstructorHelper.ErrorValidationResult<object>();

            return new ValidationResult<object>();
        }

        public virtual ValidationResult ValidateBusinessRulesForUpdate( TUpdate model )
        {
            if ( IsNotSupportedOperation<TUpdate>() )
                return ConstructorHelper.ErrorValidationResult();

            return new ValidationResult();
        }

        #endregion Validation

        #region Mapping

        protected virtual TEntity Map( TCreate model )
        {
            return Mapper.Map<TCreate, TEntity>( model );
        }

        protected virtual TEntity Map( TUpdate model, TEntity entity )
        {
            return Mapper.Map<TUpdate, TEntity>( model, entity );
        }

        protected virtual TDetails MapForDetails( TEntity entity )
        {
            return Mapper.Map<TEntity, TDetails>( entity );
        }

        protected virtual TUpdate MapForUpdate( TEntity entity )
        {
            return Mapper.Map<TEntity, TUpdate>( entity );
        }

        #endregion Mapping

        #region Get Details Model

        public OperationResult<TDetails> GetDetailsModel( object id )
        {
            var logContext = Context();

            try
            {
                if ( IsNotSupportedOperation<TDetails>() )
                    return ConstructorHelper.ErrorOperationResult<TDetails>();

                var entity = Repository.GetById( id );
                var details = MapForDetails( entity );
                return new OperationResult<TDetails>( details );
            }
            catch ( Exception ex )
            {
                try
                {
                    $"**ERROR** | Error getting details model for id <{id}>."
                        .Log( logContext, ex );
                }
                catch
                {
                    "**ERROR** | Provided id is not a valid integer!"
                        .Log( logContext, ex );
                }

                return ConstructorHelper.ErrorOperationResult<TDetails>();
            }
        }

        #endregion Get Details Model

        #region Get Update Model

        public OperationResult<TUpdate> GetUpdateModel( object id )
        {
            var logContext = Context();

            try
            {
                if ( IsNotSupportedOperation<TUpdate>() )
                    return ConstructorHelper.ErrorOperationResult<TUpdate>();

                var entity = Repository.GetById( id );
                var details = MapForUpdate( entity );
                return new OperationResult<TUpdate>( details );
            }
            catch ( Exception ex )
            {
                try
                {
                    $"**ERROR** | Error getting update model for id <{id}>."
                        .Log( logContext, ex );
                }
                catch
                {
                    $"**ERROR** | Provided id is not a valid value!"
                        .Log( logContext, ex );
                }
                return ConstructorHelper.ErrorOperationResult<TUpdate>();
            }
        }

        #endregion Get Update Model

        #region Create

        public virtual ValidationResult<object> Create( TCreate model )
        {
            return Create( null, model );
        }

        public ValidationResult<object> Create(
            BaseServiceCreateHooks<TEntity, TCreate> hooks, TCreate model )
        {
            var logContext = Context();

            try
            {
                if ( IsNotSupportedOperation<TCreate>() )
                    return ConstructorHelper.ErrorValidationResult<object>();

                #region DoBeforeCreateValidation

                if ( hooks == null )
                {
                    DoBeforeCreateValidation( model );
                }
                else
                {
                    hooks
                        .DoBeforeCreateValidation( model );
                }

                #endregion DoBeforeCreateValidation

                var validationResult = ValidateModelForCreate( model );

                #region DoAfterCreateValidation

                if ( hooks == null )
                {
                    DoAfterCreateValidation( validationResult, model );
                }
                else
                {
                    hooks
                        .DoAfterCreateValidation( validationResult, model );
                }

                #endregion DoAfterCreateValidation

                if ( validationResult.IsValid )
                {
                    _unitOfWork.BeginTransaction();

                    var entity = Map( model );

                    #region Before Create

                    IOperationResult beforeCreateResult;

                    if ( hooks == null )
                    {
                        beforeCreateResult =
                            DoBeforeCreate( entity, model );
                    }
                    else
                    {
                        beforeCreateResult = hooks
                            .DoBeforeCreate( entity, model );
                    }

                    if ( beforeCreateResult.Error )
                    {
                        _unitOfWork.Rollback();
                        validationResult.Error = true;
                        return validationResult;
                    }

                    #endregion Before Create

                    var trackedEntity = entity as ChangeTrackedEntity;
                    if ( trackedEntity != null )
                    {
                        AuditUtils.FillCreateInformation( trackedEntity, _unitOfWork.User );
                    }

                    validationResult.Result = Repository.Create( entity );

                    #region After Create

                    IOperationResult afterCreateResult;

                    if ( hooks == null )
                    {
                        afterCreateResult =
                            DoAfterCreate( entity, model );
                    }
                    else
                    {
                        afterCreateResult = hooks
                            .DoAfterCreate( entity, model );
                    }

                    if ( afterCreateResult.Error )
                    {
                        _unitOfWork.Rollback();
                        validationResult.Error = true;
                        return validationResult;
                    }

                    #endregion After Create

                    _unitOfWork.Commit();
                }
                return validationResult;
            }
            catch ( Exception ex )
            {
                _unitOfWork.Rollback();

                "**ERROR**".Log( logContext, ex );

                return ConstructorHelper.ErrorValidationResult<object>();
            }
        }

        private ValidationResult<object> ValidateModelForCreate( TCreate model )
        {
            var validationResult = new ValidationResult<object>();
            var validatable = model as IModelValidatable;
            if ( validatable != null )
            {
                validatable.Validate( validationResult );
            }
            else
            {
                ARGILValidator.ValidateAll( model, validationResult );
            }

            var businessRulesForCreateValidation = ValidateBusinessRulesForCreate( model );
            validationResult.MergeValidationResults( businessRulesForCreateValidation );
            return validationResult;
        }

        protected virtual void DoBeforeCreateValidation( TCreate model )
        {
        }

        protected virtual void DoAfterCreateValidation( ValidationResult<object> validation, TCreate model )
        {
        }

        protected virtual IOperationResult DoBeforeCreate( TEntity entity, TCreate model )
        {
            return new OperationResult();
        }

        protected virtual IOperationResult DoAfterCreate( TEntity entity, TCreate model )
        {
            return new OperationResult();
        }

        #endregion Create

        #region Update

        public ValidationResult Update( TUpdate model )
        {
            var logContext = Context();

            ValidationResult validationResult = null;
            try
            {
                ">>>".Log( logContext );

                if ( IsNotSupportedOperation<TUpdate>() )
                    return ConstructorHelper.ErrorValidationResult();

                DoBeforeUpdateValidation( model );
                validationResult = ValidateModelForUpdate( model );
                DoAfterUpdateValidation( validationResult, model );
            }
            catch ( Exception ex )
            {
                "<<< | **ERROR**".Log( logContext, ex );
                return ConstructorHelper.ErrorValidationResult();
            }

            try
            {
                if ( validationResult.IsValid )
                {
                    _unitOfWork.BeginTransaction();

                    var beforeMapResult = DoBeforeUpdateMap( model );
                    if ( beforeMapResult.Error )
                    {
                        _unitOfWork.Rollback();
                        validationResult.Error = true;
                        return validationResult;
                    }

                    var entity = Repository.GetById( GetIdFrom( model ) );
                    Repository.RemoveListElements( entity );
                    Map( model, entity );
                    AssociateReferenceKeys( entity );

                    #region Before Update

                    var beforeUpdateResult = DoBeforeUpdate( entity, model );
                    if ( beforeUpdateResult.Error )
                    {
                        _unitOfWork.Rollback();
                        validationResult.Error = true;
                        return validationResult;
                    }

                    #endregion Before Update

                    var trackedEntity = entity as ChangeTrackedEntity;
                    if ( trackedEntity != null )
                    {
                        AuditUtils.FillUpdateInformation( trackedEntity, _unitOfWork.User );
                    }

                    Repository.Update( entity );

                    #region After Update

                    var afterUpdateResult = DoAfterUpdate( entity, model );
                    if ( afterUpdateResult.Error )
                    {
                        _unitOfWork.Rollback();
                        validationResult.Error = true;
                        return validationResult;
                    }

                    #endregion After Update

                    _unitOfWork.Commit();
                }

                return "<<<".Log( logContext, validationResult );
            }
            catch ( Exception ex )
            {
                _unitOfWork.Rollback();
                "<<< | **ERROR**".Log( logContext, ex );
                return ConstructorHelper.ErrorValidationResult();
            }
        }

        private ValidationResult ValidateModelForUpdate( TUpdate model )
        {
            var validationResult = new ValidationResult();
            if ( typeof( IModelValidatable ).IsAssignableFrom( typeof( TUpdate ) ) )
            {
                ( (IModelValidatable)model ).Validate( validationResult );
            }
            else
            {
                ARGILValidator.ValidateAll( model, validationResult );
            }
            var businessValidationForUpdate = ValidateBusinessRulesForUpdate( model );
            validationResult.MergeValidationResults( businessValidationForUpdate );
            return validationResult;
        }

        protected virtual void AssociateReferenceKeys( TEntity entity )
        {
        }

        protected virtual void DoBeforeUpdateValidation( TUpdate model )
        {
        }

        protected virtual void DoAfterUpdateValidation( ValidationResult validation, TUpdate model )
        {
        }

        protected virtual IOperationResult DoBeforeUpdateMap( TUpdate model )
        {
            return new OperationResult();
        }

        protected virtual IOperationResult DoBeforeUpdate( TEntity entity, TUpdate documentoContabilisticoCreateUpdateModel )
        {
            return new OperationResult();
        }

        protected virtual IOperationResult DoAfterUpdate( TEntity entity, TUpdate model )
        {
            return new OperationResult();
        }

        #endregion Update

        #region Delete

        public OperationResult Delete( object id )
        {
            var logContext = Context();

            try
            {
                ">>>".Log( logContext );

                _unitOfWork.BeginTransaction();
                DoBeforeDelete( id );
                Repository.Delete( id );
                DoAfterDelete( id );
                _unitOfWork.Commit();

                return "<<<".Log( logContext, new OperationResult() );
            }
            catch ( Exception ex )
            {
                "<<< | **ERROR** | id={0}.".Fill( id ).Log( logContext, ex );

                _unitOfWork.TryRollback( logContext );

                return ConstructorHelper.ErrorOperationResult();
            }
        }

        protected virtual void DoBeforeDelete( object id )
        {
        }

        protected virtual void DoAfterDelete( object id )
        {
        }

        #endregion Delete

        public virtual OperationResult<IList<KeyValue>> GetKeyValueList()
        {
            var logContext = Context();
            try
            {
                ">>>".Log( logContext );

                var result = new OperationResult<IList<KeyValue>>(
                    Repository.GetKeyValueList() );

                return "<<<".Log( logContext, result );
            }
            catch ( Exception ex )
            {
                "<<< | **ERROR**".Log( logContext, ex );
                return ConstructorHelper
                    .ErrorOperationResult<IList<KeyValue>>();
            }
        }

        private bool IsNotSupportedOperation<T>()
        {
            return typeof( T ) == typeof( NotSupportedOperation );
        }

        public IEnumerable<TListItem> GetCroppedList( OperationResult<IEnumerable<TListItem>> data )
        {
            return ( data != null && data.Result != null ) ?
                data.Result.Take( GetMaxLines() ) :
                null;
        }

        protected virtual int GetMaxLines()
        {
            return 1000;
        }
    }
}