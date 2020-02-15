using MediatR;

namespace DDD.Core.Base
{
    public interface IDomainEventHandler<in T> : INotificationHandler<T> where T:IDomainEvent
    {
    }
}