using System;
using System.Threading;
using System.Threading.Tasks;


using DDD.Domain;
using DDD.Domain.Exceptions;
using MediatR;

namespace DDD.Application
{
    public class MakeGiftCommand : AbstractCommand
    {
        public Guid FromCustomerId { get; private set; }
        public Guid ToCustomerId { get; private set; }
        public decimal Amount { get; private set; }

        public MakeGiftCommand(Guid fromCustomerId, Guid toCustomerId, decimal amount)
        {
            FromCustomerId = fromCustomerId;
            ToCustomerId = toCustomerId;
            Amount = amount;
        }
    }
    public partial class Handler : ICommandHandler<MakeGiftCommand>
    {
        public async Task<ExecutionResult> Handle(MakeGiftCommand request, CancellationToken cancellationToken)
        {
            var fromCustomer = await _unitOfWork.CustomerRepo.FindByIdAsync(request.FromCustomerId);
            var toCustomer = await _unitOfWork.CustomerRepo.FindByIdAsync(request.ToCustomerId);

            if (fromCustomer == null) throw new EntityNotFoundException(request.FromCustomerId);
            if (toCustomer == null) throw new EntityNotFoundException(request.ToCustomerId);

            fromCustomer.GiftMoney(toCustomer, request.Amount);

            await _unitOfWork.CustomerRepo.Update(fromCustomer);
            await _unitOfWork.CustomerRepo.Update(toCustomer);
            await _unitOfWork.CommitAsync(cancellationToken);
            return ExecutionResult.Success();
        }
    }
}