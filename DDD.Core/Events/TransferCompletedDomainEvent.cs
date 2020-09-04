using System;
using DDD.Core.Base;


namespace DDD.Core.Events
{
    public class TransferCompletedDomainEvent : AbstractEvent
    {
        public Guid From { get; }
        public Guid To { get; }

        public decimal Amount { get; }

        public TransferCompletedDomainEvent(Guid @from, Guid to, decimal amount)
        {
            From = @from;
            To = to;
            Amount = amount;
        }
    }
}