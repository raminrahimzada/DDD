using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Base;
using DDD.Domain;
using DDD.Domain.Exceptions;
using FluentValidation;

namespace DDD.Application.Queries
{
    public class GetCustomerInfo
    {
        public class Query : AbstractQuery<Response>
        {
            public Guid CustomerId { get; set; }

            public Query()
            {

            }

            public Query(Guid customerId)
            {
                CustomerId = customerId;
            }
        }

        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(x => x.CustomerId).NotEmpty();
            }
        }
        public class Response
        {
            public string CustomerName { get; set; }
            public decimal CustomerBalance { get; set; }
            public Guid CustomerId { get; set; }
        }
        public class QueryHandler : AbstractQueryHandler<Query, Response>
        {
            private readonly IUnitOfWork _unitOfWork;

            public QueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public override async Task<Response> Handle(Query query, CancellationToken cancellationToken)
            {
                var customer = await _unitOfWork.CustomerRepo.FindByIdAsync(query.CustomerId);
                if (customer == null) throw new EntityNotFoundException(query.CustomerId);
                return new Response()
                {
                    CustomerId = customer.Id,
                    CustomerBalance = customer.Balance,
                    CustomerName = customer.Name
                };
            }

        }
    }
}
