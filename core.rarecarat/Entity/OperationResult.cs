using System;
using System.Runtime.Serialization;

namespace core.rarecarat
{
    /// <summary>
    /// 	The data contracted operation result class
    /// </summary>
    public class OperationResult : IOperationResult
    {
        /// <summary>
        /// An indicator of the operation suceess. False means no errors.
        /// </summary>
        public bool Error { get; set; }

        /// <summary>
        /// A string representing messages from the operation.
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        public void ExceptionIfFailed()
        {
            if ( Error )
            {
                throw new Exception( Message );
            }
        }

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref = "OperationResult{TResult}" /> class.
        /// </summary>
        public OperationResult() { }

        public OperationResult( string error )
            : this()
        {
            Error = true;
            Message = error;
        }

        public OperationResult( Exception e )
            : this()
        {
            Error = true;
            if ( e != null )
            {
                Message = e.Message;
            }
        }

        #endregion Ctors
    }
}