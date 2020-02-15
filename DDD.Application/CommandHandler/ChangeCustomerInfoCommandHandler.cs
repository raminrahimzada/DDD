using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Commands;
using DDD.Core;
using DDD.Core.Base;
using DDD.Core.Exceptions;
using MediatR;

namespace DDD.Application.CommandHandler
{
    public class ChangeCustomerInfoCommandHandler : ICommandHandler<ChangeCustomerInfoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeCustomerInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(ChangeCustomerInfoCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepo.FindByIdAsync(request.CustomerId);
            if (customer == null) throw new EntityNotFoundException(request.CustomerId);

            customer.ChangeInfo(request.NewName);
            _unitOfWork.CustomerRepo.Update(customer);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}