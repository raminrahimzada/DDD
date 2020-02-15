using MediatR;

namespace DDD.Core.Base
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}