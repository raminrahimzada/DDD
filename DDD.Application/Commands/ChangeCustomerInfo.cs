using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Base;
using DDD.Base;
using DDD.Domain;
using DDD.Domain.Exceptions;
using FluentValidation;

namespace DDD.Application.Commands
{
    public class ChangeCustomerInfo
    {
        public class Command : AbstractCommand
        {
            public Guid CustomerId { get; }
            public string NewName { get; }

            public Command(Guid customerId, string newName)
            {
                CustomerId = customerId;
                NewName = newName;
            }
        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.CustomerId).NotEmpty();
                RuleFor(x => x.NewName).NotEmpty();
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
                var customer = await _unitOfWork.CustomerRepo.FindByIdAsync(command.CustomerId);
                if (customer == null) throw new EntityNotFoundException(command.CustomerId);

                customer.ChangeInfo(command.NewName);
                _unitOfWork.CustomerRepo.Update(customer);
                await _unitOfWork.CommitAsync(cancellationToken);

                return ExecutionResult.Success;
            }
        }
    }
}
