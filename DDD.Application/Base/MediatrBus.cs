using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Base;
using MediatR;

namespace DDD.Application.Base
{
    public class MediatrBus : IGenericBus
    {
        private readonly IMediator _mediator;

        public MediatrBus(IMediator mediator)
        {
            _mediator = mediator ?? throw new Exception($"Missing dependency '{nameof(IMediator)}'");
        }

        public async Task Publish(params IDomainEvent[] domainEvents)
        {
            foreach (var @event in domainEvents)
            {
                await _mediator.Publish(@event);
            }
        }

        public Task<ExecutionResult> Send(ICommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            var commandForMediatr = (IRequest<ExecutionResult>) command;
            return _mediator.Send(commandForMediatr, cancellationToken);
        }

        public Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var queryForMediatr = (IRequest<TResponse>)query;
            return _mediator.Send(queryForMediatr, cancellationToken);
        }
    }
}