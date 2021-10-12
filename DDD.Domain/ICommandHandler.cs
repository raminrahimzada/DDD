using MediatR;

namespace DDD.Domain
{    
    public  interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, ExecutionResult> where TCommand:AbstractCommand
    {
    }
}
