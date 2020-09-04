using DDD.Base;
using MediatR;

namespace DDD.Application.Base
{
    public abstract class AbstractQuery<TResponse> : IRequest<TResponse>, IQuery<TResponse>
    {

    }
}