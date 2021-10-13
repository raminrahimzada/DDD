using System;

namespace DDD.Domain
{
    public class ExecutionResult<TResponse> : ExecutionResult
    {
        public TResponse Response { get; set; }

        protected ExecutionResult(bool isSuccess, string errorCode, string errorDescription,TResponse response) 
            : base(isSuccess, errorCode,errorDescription)
        {
            Response = response;
        }

        public static ExecutionResult<TResponse> Success(TResponse response)
        {
            return new ExecutionResult<TResponse>(true, null, null, response);
        }

        public new static ExecutionResult<TResponse> Fail(string errorCode,string errorDescription)
        {
            return new ExecutionResult<TResponse>(false, errorCode,errorDescription, default);
        }
        public new static ExecutionResult<TResponse> Fail(Exception e)
        {
            return new ExecutionResult<TResponse>(false, e?.GetType()?.Name ?? "Exception", e?.Message, default);
        }
    }
}
