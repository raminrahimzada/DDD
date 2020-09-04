using System.Threading;
using System.Threading.Tasks;
using DDD.Base;
using MediatR;

namespace DDD.Application.Base
{
    public abstract class AbstractCommandHandler<TCommand>
        : ICommandHandler<TCommand>
            , IRequestHandler<TCommand, ExecutionResult> where TCommand : AbstractCommand, IRequest<ExecutionResult>
    {
        public abstract Task<ExecutionResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}