
//using MediatR;

namespace DDD.Application
{
    //public interface ICustomMediator
    //{
    //    Task Publish<TDomainEvent>(TDomainEvent notification, CancellationToken cancellationToken = default) where TDomainEvent : IDomainEvent;
    //    Task Send(ICommand request, CancellationToken cancellationToken = default);
    //    Task<TResponse> Send<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken = default);
    //}

    //public class CustomMediator : ICustomMediator
    //{
    //    private readonly IMediator _mediator;
    //    private readonly IEventStore _eventStore;

    //    public CustomMediator(IMediator mediator, IEventStore eventStore)
    //    {
    //        _mediator = mediator;
    //        _eventStore = eventStore;
    //    }


    //    public Task Publish<TDomainEvent>(TDomainEvent notification, CancellationToken cancellationToken = default) where TDomainEvent : IDomainEvent
    //    {
    //        _eventStore.AddEvent(notification);
    //        return _mediator.Publish(notification, cancellationToken);
    //    }

    //    public Task Send(ICommand request, CancellationToken cancellationToken = default)
    //    {
    //        _eventStore.AddCommand(request);
    //        return _mediator.Send(request, cancellationToken);
    //    }

    //    public Task<TResponse> Send<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken = default)
    //    {
    //        _eventStore.AddQuery(request);
    //        return _mediator.Send(request, cancellationToken);
    //    }
    //}
}