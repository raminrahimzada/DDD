using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Events;

namespace DDD.Application
{
    public partial class Handler :
        IEventHandler<CustomerInfoChangedDomainEvent>
    {
        public Task Handle(CustomerInfoChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            //TODO
            return Task.CompletedTask;
        }
    }
}