using System;
using DDD.Core.Base;

namespace DDD.Core.Aggregates.TransactionAggregate
{
    public class Transaction:Entity,IAggregateRoot
    {
        public Guid FromCustomerId { get;private set; }
        public Guid ToCustomerId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime When { get; private set; }

        public Transaction(Guid fromCustomerId, Guid toCustomerId, decimal amount, DateTime @when)
        {
            FromCustomerId = fromCustomerId;
            ToCustomerId = toCustomerId;
            Amount = amount;
            When = when;
        }
    }
}
