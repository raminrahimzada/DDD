using MediatR;

namespace DDD.Domain
{
    public interface IQueryHandler<in TQuery, TResponse> :
        IRequestHandler<TQuery, ExecutionResult<TResponse>> where TQuery : AbstractQuery<TResponse>
    {
    }   
}
