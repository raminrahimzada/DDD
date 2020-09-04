using System;

namespace DDD.Core.Exceptions
{
    public class EntityNotFoundException : DomainException
    {
        public override string ErrorCode => "ENTITY_NOT_FOUND";
        public Guid Id { get; set; }

        public EntityNotFoundException(Guid id)
        {
            Id = id;
        }

        public override string Message => "No Entity found with Id = " + Id;
    }
}