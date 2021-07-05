namespace core.rarecarat
{
    public interface IOperationResult
    {
        bool Error { get; set; }
        string Message { get; set; }
    }

    public interface IOperationResult<TResult> : IOperationResult
    {
        TResult Result { get; set; }
    }
}