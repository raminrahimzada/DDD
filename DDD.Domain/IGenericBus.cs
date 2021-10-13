using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Base;

namespace DDD.Domain
{
    public interface IGenericBus
    {
        Task Publish(params IDomainEvent[] domainEvents);
        Task<ExecutionResult> Send(AbstractCommand command, CancellationToken cancellationToken);

        Task<ExecutionResult<TResponse>> Send<TResponse>(AbstractQuery<TResponse> query,
            CancellationToken cancellationToken);
    }
}