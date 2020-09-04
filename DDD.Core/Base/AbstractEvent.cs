using System;
using DDD.Base;
using MediatR;

namespace DDD.Core.Base
{
    public abstract class AbstractEvent : IEvent,INotification
    {
        public Guid Id { get; set; }

        protected AbstractEvent()
        {
            Id = Guid.NewGuid();
        }
    }
}