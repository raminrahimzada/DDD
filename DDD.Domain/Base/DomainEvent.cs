using System;
using DDD.Base;
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