using MediatR;

namespace DDD.Core.Base
{
    public interface IQueryHandler<in TCommand,TResponse> 
        : 
            IRequestHandler<TCommand, TResponse> 
        where TCommand : IQuery<TResponse>
    {
    }
}