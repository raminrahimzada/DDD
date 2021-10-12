using MediatR;

namespace DDD.Domain
{
    public abstract class AbstractQuery<TResponse> : IRequest<ExecutionResult<TResponse>>
    {
    }
}
