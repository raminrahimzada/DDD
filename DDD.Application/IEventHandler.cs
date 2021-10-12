using DDD.Domain.Base;
using MediatR;

namespace DDD.Application
{
    public interface IEventHandler<in TEvent> :  INotificationHandler<TEvent>
        where TEvent : DomainEvent
    {
    }
}