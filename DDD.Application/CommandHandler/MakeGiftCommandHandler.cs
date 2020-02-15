using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Commands;
using DDD.Core;
using DDD.Core.Base;
using DDD.Core.Exceptions;
using MediatR;

namespace DDD.Application.CommandHandler
{
    public class MakeGiftCommandHandler : ICommandHandler<MakeGiftCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public MakeGiftCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(MakeGiftCommand request, CancellationToken cancellationToken)
        {
            var fromCustomer = await _unitOfWork.CustomerRepo.FindByIdAsync(request.FromCustomerId);
            var toCustomer = await _unitOfWork.CustomerRepo.FindByIdAsync(request.ToCustomerId);

            if (fromCustomer == null) throw new EntityNotFoundException(request.FromCustomerId);
            if (toCustomer == null) throw new EntityNotFoundException(request.ToCustomerId);

            fromCustomer.GiftMoney(toCustomer, request.Amount);
            
            _unitOfWork.CustomerRepo.Update(fromCustomer);
            _unitOfWork.CustomerRepo.Update(toCustomer);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}