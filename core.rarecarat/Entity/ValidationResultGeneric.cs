using System;

namespace core.rarecarat
{
    /// <summary>
    /// 	The data contracted validation result class of closed generic.
    /// 	This type includes possible validation messages as result of an Operation that
    /// 	performs validation.
    /// </summary>
    /// <typeparam name = "TResult">The type of data expected for the returning result.</typeparam>
    public class ValidationResult<TResult> : ValidationResult, IOperationResult<TResult>
    {
        #region Ctors

        public ValidationResult()
            : base()
        {
        }

        public ValidationResult( string message ) : base( message )
        {
        }

        public ValidationResult( Exception e ) : base( e )
        {
        }

        public ValidationResult( Exception e, TResult result )
        {
            Result = result;
            Error = true;
            if ( e != null )
            {
                Message = e.Message;
            }
        }

        public ValidationResult( OperationResult<TResult> operationResult )
        {
            Result = operationResult.Result;
            Error = operationResult.Error;
            Message = operationResult.Message;
        }

        /// <summary>
        /// 	Initializes a new instance of the <see cref = "OperationResult{TResult}" /> class.
        /// </summary>
        /// <param name = "result">
        /// 	The result.
        /// </param>
        /// <param name = "error">
        /// 	The error.
        /// </param>
        /// <param name = "message"></param>
        public ValidationResult( TResult result, bool error = false, string message = null )
        {
            Result = result;
            Error = error;
            if ( error )
            {
                Message = message;
            }
        }

        #endregion Ctors

        public TResult Result { get; set; }
    }
}