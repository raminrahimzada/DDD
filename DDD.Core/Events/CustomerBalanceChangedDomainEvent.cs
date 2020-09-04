using System;
using DDD.Core.Base;


namespace DDD.Core.Events
{
    public class CustomerBalanceChangedDomainEvent : AbstractEvent
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