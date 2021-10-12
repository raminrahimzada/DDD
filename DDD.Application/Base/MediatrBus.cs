using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using DDD.Domain;
using DDD.Domain.Base;
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

        public Task<ExecutionResult> Send(AbstractCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _mediator.Send(command, cancellationToken);
        }

        public Task<ExecutionResult<TResponse>> Send<TResponse>(AbstractQuery<TResponse> query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _mediator.Send(query, cancellationToken);
        }
    }
}