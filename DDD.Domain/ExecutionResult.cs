using System;

namespace DDD.Domain
{
    public class ExecutionResult : IEquatable<ExecutionResult>
    {
        public bool IsSucceed { get; }
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }

        protected ExecutionResult(bool isSuccess,string errorCode,string errorDescription)
        {
            IsSucceed = isSuccess;
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }
        public static ExecutionResult<TResponse> Success<TResponse>(TResponse response)
        {
            return ExecutionResult<TResponse>.Success(response);
        }
        public static ExecutionResult Success()
        {
            return new ExecutionResult(true, null, null);
        }
        public static ExecutionResult Fail(string errorCode,string errorDescription="Something bad happened :(") => new ExecutionResult(false, errorCode,errorDescription);
        public static ExecutionResult Fail(Exception e)
        {
            return new ExecutionResult(false, e.GetType().Name, e.Message);
        }
        public override bool Equals(object obj)
        {
            if (obj is ExecutionResult e)
            {
                return e.IsSucceed.Equals(IsSucceed);
            }

            return ReferenceEquals(this, obj);
        }

        public bool Equals(ExecutionResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return IsSucceed == other.IsSucceed && ErrorCode == other.ErrorCode;
        }

        public override int GetHashCode()
        {
            return (int) (IsSucceed.GetHashCode() ^ ErrorCode?.GetHashCode());
        }

        public static bool operator ==(ExecutionResult left, ExecutionResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ExecutionResult left, ExecutionResult right)
        {
            return !Equals(left, right);
        }
    }
}
