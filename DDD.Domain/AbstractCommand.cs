using MediatR;

namespace DDD.Domain
{
    public class AbstractCommand : IRequest<ExecutionResult>
    {
    }
}
