using ARGIL.Core.IModels;
using ARGIL.Core.IRepository;
using ARGIL.Utils.Entity;
using System;

namespace ARGIL.Core
{
    #region Create Hooks

    public class BaseServiceCreateHooks<TEntity, TCreate>
        where TCreate : ICreateModel
        where TEntity : IEntity
    {
        private Action<TCreate> DoBeforeCreateValidationHook { get; set; }
        private Action<ValidationResult<object>, TCreate> DoAfterCreateValidationHook { get; set; }
        private Func<TEntity, TCreate, IOperationResult> DoBeforeCreateHook { get; set; }
        private Func<TEntity, TCreate, IOperationResult> DoAfterCreateHook { get; set; }

        public BaseServiceCreateHooks<TEntity, TCreate> OnBeforeCreateValidation( Action<TCreate> hook )

        {
            if ( DoBeforeCreateValidationHook != null )
            {
                throw new ArgumentException( "Hook already defined" );
            }

            DoBeforeCreateValidationHook = hook;
            return this;
        }

        public BaseServiceCreateHooks<TEntity, TCreate> OnAfterCreateValidation( Action<ValidationResult<object>, TCreate> hook )
        {
            if ( DoAfterCreateValidationHook != null )
            {
                throw new ArgumentException( "Hook already defined" );
            }

            DoAfterCreateValidationHook = hook;
            return this;
        }

        public BaseServiceCreateHooks<TEntity, TCreate> OnBeforeCreate( Func<TEntity, TCreate, IOperationResult> hook )
        {
            if ( DoBeforeCreateHook != null )
            {
                throw new ArgumentException( "Hook already defined" );
            }

            DoBeforeCreateHook = hook;

            return this;
        }

        public BaseServiceCreateHooks<TEntity, TCreate> OnAfterCreate( Func<TEntity, TCreate, IOperationResult> hook )
        {
            if ( DoAfterCreateHook != null )
            {
                throw new ArgumentException( "Hook already defined" );
            }

            DoAfterCreateHook = hook;

            return this;
        }

        public void DoBeforeCreateValidation( TCreate model )
        {
            DoBeforeCreateValidationHook?
                .Invoke( model );
        }

        public void DoAfterCreateValidation( ValidationResult<object> validation, TCreate model )
        {
            DoAfterCreateValidationHook?
                .Invoke( validation, model );
        }

        public IOperationResult DoBeforeCreate( TEntity entity, TCreate model )
        {
            return DoBeforeCreateHook?
                .Invoke( entity, model ) ??
                new OperationResult();
        }

        public IOperationResult DoAfterCreate( TEntity entity, TCreate model )
        {
            return DoAfterCreateHook?
                .Invoke( entity, model ) ??
                new OperationResult(); ;
        }
    }

    #endregion Create Hooks

    #region Update Hooks

    //TODO

    #endregion Update Hooks

    #region Delete Hooks

    //TODO

    #endregion Delete Hooks
}