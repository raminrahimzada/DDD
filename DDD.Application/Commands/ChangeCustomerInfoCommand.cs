using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Domain;
using DDD.Domain.Exceptions;
using MediatR;

namespace DDD.Application
{
    public class ChangeCustomerInfoCommand: AbstractCommand
    {
        public Guid CustomerId { get;private set; }
        public string NewName { get; private set; }

        public ChangeCustomerInfoCommand(Guid customerId, string newName)
        {
            CustomerId = customerId;
            NewName = newName;
        }
    }

    public partial class Handler : ICommandHandler<ChangeCustomerInfoCommand>
    {
        public async Task<ExecutionResult> Handle(ChangeCustomerInfoCommand request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepo.FindByIdAsync(request.CustomerId);
            if (customer == null) throw new EntityNotFoundException(request.CustomerId);

            customer.ChangeInfo(request.NewName);
            await _unitOfWork.CustomerRepo.Update(customer);
            await _unitOfWork.CommitAsync(cancellationToken);
            return ExecutionResult.Success();
        }
    }
}
