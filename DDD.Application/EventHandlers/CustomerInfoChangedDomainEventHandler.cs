﻿using System.Threading;
using System.Threading.Tasks;
using DDD.Core.Base;
using DDD.Core.Events;

namespace DDD.Application.EventHandlers
{
    public class CustomerInfoChangedDomainEventHandler :
        AbstractEventHandler<CustomerInfoChangedDomainEvent>
    {
        public override Task Handle(CustomerInfoChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            //TODO
            return Task.CompletedTask;
        }
    }
}