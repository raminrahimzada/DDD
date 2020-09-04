using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Base;
using DDD.Domain.Events;

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