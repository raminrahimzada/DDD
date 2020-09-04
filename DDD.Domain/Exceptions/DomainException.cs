using System;

namespace DDD.Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        public abstract string ErrorCode { get;}
        public override string ToString()
        {
            return ErrorCode;
        }
    }
}