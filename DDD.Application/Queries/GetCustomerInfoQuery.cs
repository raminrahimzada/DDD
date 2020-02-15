using System;
using DDD.Core.Aggregates.CustomerAggregate;

namespace DDD.Application.Queries
{
    public class GetCustomerInfoQuery:QueryBase<Customer>
    {
        public Guid CustomerId { get; private set; }

        public GetCustomerInfoQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
