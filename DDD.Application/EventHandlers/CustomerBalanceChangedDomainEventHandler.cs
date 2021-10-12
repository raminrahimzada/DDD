using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Base;
using DDD.Domain.Events;

namespace DDD.Application
{
    public partial class Handler:
        IEventHandler<CustomerBalanceChangedDomainEvent>
    {
        public Task Handle(CustomerBalanceChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            //TODO
            return Task.CompletedTask;
        }
    }
}
