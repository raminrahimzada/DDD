using System;
using System.Threading;
using System.Threading.Tasks;



using DDD.Domain;
using DDD.Domain.Aggregates.CustomerAggregate;

namespace DDD.Application
{
    public class CreateCustomerCommand : AbstractCommand 
    {
        public Guid Id { get; }
        public string Name { get; }

        public CreateCustomerCommand(Guid id,string name)
        {
            Id = id;
            Name = name;
        }
    }

    public partial class Handler : ICommandHandler<CreateCustomerCommand>
    {
        public async Task<ExecutionResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            const decimal defaultCustomerBalance = 100M;
            var customer = new Customer(request.Id, request.Name, defaultCustomerBalance);
            await _unitOfWork.CustomerRepo.Add(customer);
            await _unitOfWork.CommitAsync(cancellationToken);
            return ExecutionResult.Success();
        }
    }
}