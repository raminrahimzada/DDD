using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Queries;
using DDD.Core;
using DDD.Core.Aggregates.CustomerAggregate;
using DDD.Core.Base;
using DDD.Core.Exceptions;

namespace DDD.Application.QueryHandlers
{
   public class GetCustomerInfoQueryHandler:IQueryHandler<GetCustomerInfoQuery,Customer>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerInfoQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Customer> Handle(GetCustomerInfoQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepo.FindByIdAsync(request.CustomerId);
            if (customer == null) throw new EntityNotFoundException(request.CustomerId);
            return customer;
        }
    }
}
