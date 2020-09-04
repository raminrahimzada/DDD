using System.Threading;
using System.Threading.Tasks;
using DDD.Base;
using MediatR;

namespace DDD.Core.Base
{
    public abstract class AbstractEventHandler<TEvent> : IEventHandler<TEvent>, INotificationHandler<TEvent>
        where TEvent : AbstractEvent
    {
        public abstract Task Handle(TEvent notification, CancellationToken cancellationToken);
    }
}