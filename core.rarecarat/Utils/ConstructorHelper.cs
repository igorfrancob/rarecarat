using System;
using System.Collections.Generic;
using System.Linq;

namespace core.rarecarat
{
    public static class ConstructorHelper
    {
        public static OperationResult ErrorOperationResult()
        {
            return new OperationResult("error occurred");
        }

        public static OperationResult ErrorOperationResult(string message)
        {
            return new OperationResult(message);
        }

        public static OperationResult ErrorOperationResult(Exception ex)
        {
            return new OperationResult(ex);
        }

        public static OperationResult<T> ErrorOperationResult<T>()
        {
            return new OperationResult<T>("error occurred");
        }

        public static OperationResult<T> ErrorOperationResult<T>(Exception ex)
        {
            return new OperationResult<T>(ex);
        }

        public static OperationResult<T> ErrorOperationResult<T>(string message)
        {
            return new OperationResult<T>(message);
        }

        public static ValidationResult ErrorValidationResult()
        {
            //Ocorreu um erro a processar o seu pedido
            return new ValidationResult("error occurred");
        }

        public static ValidationResult ErrorValidationResult(string message)
        {
            return new ValidationResult(message);
        }

        public static ValidationResult<T> ErrorValidationResult<T>()
        {
            return new ValidationResult<T>(default(T), true, "error occurred");
        }

        public static ValidationResult<T> ErrorValidationResult<T>(string message)
        {
            return new ValidationResult<T>(default(T), true, message);
        }

        //public static void AddValidationResults( this ValidationResult validation, IEnumerable<ELValidationResult> results )
        //{
        //    foreach ( var res in results )
        //    {
        //        validation.AddErrorValidationItem( res.Key, res.Message );
        //    }
        //}

        //public static void AddValidationResults( this ValidationResult validation, IEnumerable<ELValidationResult> results, string prefix )
        //{
        //    foreach ( var res in results )
        //    {
        //        validation.AddErrorValidationItem( prefix, res.Key, res.Message );
        //    }
        //}

        public static void AddPrefixToErrors(this ValidationResult validation, string prefix)
        {
            foreach (var error in validation.ValidationErrors)
            {
                error.PropertyName = prefix + "." + error.PropertyName;
            }
        }

        public static void AddErrorValidationItem(this ValidationResult validation, string prefix, string propName, string message)
        {
            if (!string.IsNullOrEmpty(prefix))
                propName = prefix + "." + propName;

            if (!(validation.ValidationErrors.Any(i => i.PropertyName == propName)))
                validation.AddErrorValidationItem(propName, message);
        }
    }
}