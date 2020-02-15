using System.Threading;
using System.Threading.Tasks;
using DDD.Core.Base;
using DDD.Core.Events;

namespace DDD.Application.DomainEventHandlers
{
    public class CustomerInfoChangedDomainEventHandler : IDomainEventHandler<CustomerInfoChangedDomainEvent>
    {
        public async Task Handle(CustomerInfoChangedDomainEvent notification, CancellationToken cancellationToken)
        {
        }
    }
}