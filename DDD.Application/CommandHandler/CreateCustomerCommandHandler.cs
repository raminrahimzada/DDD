using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Commands;
using DDD.Core;
using DDD.Core.Aggregates.CustomerAggregate;
using DDD.Core.Base;
using MediatR;

namespace DDD.Application.CommandHandler
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            const decimal defaultCustomerBalance = 100M;
            var customer = new Customer(request.Id, request.Name, defaultCustomerBalance);
            await _unitOfWork.CustomerRepo.Add(customer);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}