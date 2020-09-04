using System.Threading;
using System.Threading.Tasks;
using DDD.Base;
using MediatR;

namespace DDD.Core.Base
{
    public abstract class AbstractQueryHandler<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>,
        IRequestHandler<TQuery, TResponse> where TQuery : AbstractQuery<TResponse>
    {
        public abstract Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken);
    }
}