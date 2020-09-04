using System.Threading;
using System.Threading.Tasks;
using DDD.Base;
using DDD.Domain.Base;
using MediatR;

namespace DDD.Application.Base
{
    public abstract class AbstractEventHandler<TEvent> : IEventHandler<TEvent>, INotificationHandler<TEvent>
        where TEvent : DomainEvent
    {
        public abstract Task Handle(TEvent notification, CancellationToken cancellationToken);
    }
}