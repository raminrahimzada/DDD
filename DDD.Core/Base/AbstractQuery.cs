using DDD.Base;
using MediatR;

namespace DDD.Core.Base
{
    public abstract class AbstractQuery<TResponse> : IRequest<TResponse>, IQuery<TResponse>
    {

    }
}