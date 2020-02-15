using System.Threading;
using System.Threading.Tasks;
using DDD.Core.Base;
using DDD.Core.Events;

namespace DDD.Application.DomainEventHandlers
{
    public class CustomerBalanceChangedDomainEventHandler:IDomainEventHandler<CustomerBalanceChangedDomainEvent>
    {
        public async Task Handle(CustomerBalanceChangedDomainEvent notification, CancellationToken cancellationToken)
        {
        }
    }
}
