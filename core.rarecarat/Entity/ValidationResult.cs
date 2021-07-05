using System;
using System.Collections.Generic;
using System.Linq;

namespace core.rarecarat
{
    /// <summary>
    /// 	The data contracted validation result class .
    /// 	This type includes possible validation messages as result of an Operation that
    /// 	performs validation.
    /// </summary>
    public class ValidationResult : IValidationResult
    {
        #region Ctors

        /// <summary>
        /// 	Initializes a new instance of the <see cref = "OperationResult{TResult}" /> class.
        /// </summary>
        public ValidationResult()
        {
            IsValid = true;
            ValidationErrors = new List<ValidationItem>();
        }

        public ValidationResult( string error )
            : this()
        {
            Error = true;
            Message = error;
        }

        public ValidationResult( Exception e ) : this( e.Message )
        {
        }

        #endregion Ctors

        #region Props

        public bool Error { get; set; }
        public string Message { get; set; }

        public bool IsValid { get; set; }
        public List<ValidationItem> ValidationErrors { get; set; }

        #endregion Props

        #region Methods

        public void AddErrorValidationItem( string message )
        {
            AddErrorValidationItem( "", message );
        }

        public void AddErrorValidationItem( string propName, string message )
        {
            IsValid = false;
            ValidationErrors.Add( new ValidationItem()
            {
                PropertyName = propName,
                Message = message
            } );
        }

        public void AddErrorValidationItem( string propName, Exception exception )
        {
            IsValid = false;
            ValidationErrors.Add( new ValidationItem()
            {
                PropertyName = propName,
                Exception = exception
            } );
        }

        public void AddErrorValidationItems( IEnumerable<ValidationItem> items )
        {
            var validationItems = items as IList<ValidationItem> ?? items.ToList();
            if (validationItems != null && validationItems.Count > 0)
            {
                IsValid = false;
                ValidationErrors.AddRange( validationItems );
            }
        }

        public void MergeValidationResults( ValidationResult resultToMerge )
        {
            Error &= resultToMerge.Error;
            Message = resultToMerge.Message;
            IsValid &= resultToMerge.IsValid;
            ValidationErrors.AddRange( resultToMerge.ValidationErrors.Where( ValidationItem => !ValidationErrors.Contains( ValidationItem ) ) );
        }

        #endregion Methods
    }
}