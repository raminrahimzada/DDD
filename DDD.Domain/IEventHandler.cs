using DDD.Domain.Base;
using MediatR;

namespace DDD.Domain
{
    public interface IEventHandler<in TEvent> :  INotificationHandler<TEvent>
        where TEvent : DomainEvent
    {
    }
}