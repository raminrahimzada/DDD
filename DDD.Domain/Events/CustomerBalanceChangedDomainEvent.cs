using System;
using DDD.Domain.Base;

namespace DDD.Domain.Events
{
    public class CustomerBalanceChangedDomainEvent : DomainEvent
    {
        public Guid CustomerId { get; }
        public decimal OldAmount { get; }
        public decimal NewAmount { get; }

        public CustomerBalanceChangedDomainEvent(Guid customerId, decimal oldAmount, decimal newAmount)
        {
            CustomerId = customerId;
            OldAmount = oldAmount;
            NewAmount = newAmount;
        }
    }
}