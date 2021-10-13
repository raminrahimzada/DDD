using System;
using System.Threading;
using System.Threading.Tasks;



using DDD.Domain;
using DDD.Domain.Aggregates.CustomerAggregate;
using FluentValidation;

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

    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEqual(string.Empty);
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