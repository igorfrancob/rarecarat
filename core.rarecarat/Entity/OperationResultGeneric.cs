using System;

namespace core.rarecarat
{
    /// <summary>
    /// 	The data contracted operation result class of closed generic.
    /// </summary>
    /// <typeparam name = "TResult">The type of data expected for the returning result.</typeparam>
    public class OperationResult<TResult> : OperationResult, IOperationResult<TResult>
    {
        /// <summary>
        /// 	The operation result data.
        /// </summary>
        public TResult Result { get; set; }

        public TResult ResultOrExceptionIfFailed()
        {
            if ( Error )
            {
                throw new Exception( Message );
            }

            return Result;
        }

        #region Ctors

        public OperationResult()
        {
        }

        public OperationResult( string message ) : base( message )
        {
        }

        public OperationResult( Exception e ) : base( e )
        {
        }

        public OperationResult( Exception e, TResult result )
        {
            Result = result;
            Error = true;
            if ( e != null )
            {
                Message = e.Message;
            }
        }

        public OperationResult( OperationResult<TResult> operationResult )
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
        public OperationResult( TResult result, bool error = false, string message = null )
        {
            Result = result;
            Error = error;
            if ( error )
            {
                Message = message;
            }
        }

        #endregion Ctors
    }
}