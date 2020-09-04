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
    public class MakeGift
    {
        public class Command : AbstractCommand
        {
            public Guid FromCustomerId { get; set; }
            public Guid ToCustomerId { get; set; }
            public decimal Amount { get; set; }

            public Command()
            {

            }

            public Command(Guid fromCustomerId, Guid toCustomerId, decimal amount)
            {
                FromCustomerId = fromCustomerId;
                ToCustomerId = toCustomerId;
                Amount = amount;
            }
        }
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.FromCustomerId).NotEmpty();
                RuleFor(x => x.ToCustomerId).NotEmpty();
                RuleFor(x => x.Amount).NotEmpty();
                RuleFor(x => x.Amount).GreaterThan(0.0M);
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
                var fromCustomer = await _unitOfWork.CustomerRepo.FindByIdAsync(command.FromCustomerId);
                var toCustomer = await _unitOfWork.CustomerRepo.FindByIdAsync(command.ToCustomerId);

                if (fromCustomer == null) throw new EntityNotFoundException(command.FromCustomerId);
                if (toCustomer == null) throw new EntityNotFoundException(command.ToCustomerId);

                fromCustomer.GiftMoney(toCustomer, command.Amount);

                _unitOfWork.CustomerRepo.Update(fromCustomer);
                _unitOfWork.CustomerRepo.Update(toCustomer);
                await _unitOfWork.CommitAsync(cancellationToken);

                return ExecutionResult.Success;
            }
        }
    }
}