using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Base;
using DDD.Base;
using DDD.Domain;
using DDD.Domain.Aggregates.CustomerAggregate;
using FluentValidation;

namespace DDD.Application.Commands
{
    public class CreateCustomer
    {
        public class Command : AbstractCommand
        {
            public Guid CustomerId { get; set; }
            public string CustomerName { get; set; }

            public Command()
            {

            }

            public Command(Guid customerId, string customerName)
            {
                CustomerId = customerId;
                CustomerName = customerName;
            }
        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.CustomerId).NotEmpty();
                RuleFor(x => x.CustomerName).NotEmpty();
            }
        }
        public class CommandHandler :
            AbstractCommandHandler<Command>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public override async Task<ExecutionResult> Handle(Command command,
                CancellationToken cancellationToken)
            {
                const decimal defaultCustomerBalance = 100M;
                var customer = new Customer(command.CustomerId, command.CustomerName, defaultCustomerBalance);
                customer.ChangeInfo(command.CustomerName);
                await _unitOfWork.CustomerRepo.Add(customer);
                await _unitOfWork.CommitAsync(cancellationToken);
                return ExecutionResult.Success;
            }
        }
    }

}
