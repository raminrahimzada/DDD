using System.Threading;
using System.Threading.Tasks;

namespace DDD.Base
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<ExecutionResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
    public interface IGenericBus
    {
        Task Publish(params IDomainEvent[] domainEvents);
        Task<ExecutionResult> Send(ICommand command, CancellationToken cancellationToken = default(CancellationToken));
        Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default(CancellationToken));
    }

   
    public class ExecutionResult
    {
        public bool IsSucceed { get; }

        private static ExecutionResult _success=>new ExecutionResult(true);
        private static ExecutionResult _fail => new ExecutionResult(false);

        private ExecutionResult(bool isSuccess)
        {
            IsSucceed = isSuccess;
        }
        public static ExecutionResult Success => _success;
        public static ExecutionResult Fail => _fail;
    }
    
}