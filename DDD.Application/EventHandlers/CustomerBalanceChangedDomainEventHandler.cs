using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Base;
using DDD.Domain.Events;

namespace DDD.Application.EventHandlers
{
    public class CustomerBalanceChangedDomainEventHandler:
        AbstractEventHandler<CustomerBalanceChangedDomainEvent>
    {
        public override Task Handle(CustomerBalanceChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            //TODO
            return Task.CompletedTask;
        }
    }
}
