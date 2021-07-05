using ARGIL.Core.IModels;
using ARGIL.Core.IRepository;
using ARGIL.Utils.Entity;
using System;

namespace ARGIL.Core
{
    public abstract class BaseServiceUnhooked<TEntity, TCreate, TUpdate, TDetails, TListItem> : BaseService<TEntity, TCreate, TUpdate, TDetails, TListItem>
        where TCreate : ICreateModel
        where TUpdate : IUpdateModel
        where TDetails : IDetailsModel
        where TListItem : IListItemModel
        where TEntity : IEntity
    {
        public BaseServiceUnhooked( IUnitOfWork unitOfWork, ILogger logger ) : base( unitOfWork, logger )
        {
        }

        #region Create

        sealed protected override void DoBeforeCreateValidation( TCreate model )
        {
            throw new NotSupportedException();
        }

        sealed protected override void DoAfterCreateValidation( ValidationResult<object> validation, TCreate model )
        {
            throw new NotSupportedException();
        }

        sealed protected override IOperationResult DoBeforeCreate( TEntity entity, TCreate model )
        {
            throw new NotSupportedException();
        }

        sealed protected override IOperationResult DoAfterCreate( TEntity entity, TCreate model )
        {
            throw new NotSupportedException();
        }

        protected BaseServiceCreateHooks<TEntity, TCreate> OnCreate()
        {
            return new BaseServiceCreateHooks<TEntity, TCreate>();
        }

        /// <summary>
        /// Este método pode e deve ser "overrided" de modo a passar os hooks pretendidos.
        /// Toda a lógica de criação deverá estar no método da classe base
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override ValidationResult<object> Create( TCreate model )
        {
            // Neste versão "unhooked" passamos sempre uma instancia do objecto que representa os
            // hooks inicializada por omissão. Isto é importante porque esta class faz override dos métodos base
            // de modo a inutilizá-los com exceptions e a impedir que sejam overrided. Se não passarmos este instancia
            // o comportamento padrão atual deixa de funcionar quando não passamos hooks.
            return Create( OnCreate(), model );
        }

        #endregion Create

        #region Update

        //TODO

        #endregion Update

        #region Delete

        //TODO

        #endregion Delete
    }
}