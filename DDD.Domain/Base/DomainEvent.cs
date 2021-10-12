using System;
using MediatR;

namespace DDD.Domain.Base
{
    public abstract class DomainEvent : IDomainEvent,INotification
    {
        public Guid Id { get; set; }

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
        }
    }
}