using DDD.Core.Aggregates.CustomerAggregate;
using DDD.Core.Base;

namespace DDD.Core.Events
{
    public class TransferCompletedDomainEvent : IDomainEvent
    {
        public Customer From { get; }
        public Customer To { get; }

        public decimal Amount { get; }

        public TransferCompletedDomainEvent(Customer @from, Customer to, decimal amount)
        {
            From = @from;
            To = to;
            Amount = amount;
        }
    }
}