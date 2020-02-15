using MediatR;

namespace DDD.Core.Base
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand:ICommand
    {
    }
}