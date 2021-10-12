using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Domain;
using DDD.Domain.Exceptions;


namespace DDD.Application
{
    public class GetCustomerInfoQuery: AbstractQuery<CustomerDTO>
    {
        public Guid CustomerId { get; private set; }

        public GetCustomerInfoQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }

    public partial class Handler : IQueryHandler<GetCustomerInfoQuery, CustomerDTO>
    {
        public async Task<ExecutionResult<CustomerDTO>> Handle(GetCustomerInfoQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepo.FindByIdAsync(request.CustomerId);
            if (customer == null) throw new EntityNotFoundException(request.CustomerId);
            var dto = new CustomerDTO
            {
                Id = customer.Id,
                Balance = customer.Balance,
                Name = customer.Name
            };
            return ExecutionResult.Success(dto);
        }
    }
}
