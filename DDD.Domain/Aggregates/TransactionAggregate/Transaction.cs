using System;
using DDD.Domain.Base;

namespace DDD.Domain.Aggregates.TransactionAggregate
{
    public class Transaction: AggregateRoot
    {
        public Guid FromCustomerId { get;private set; }
        public Guid ToCustomerId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime When { get; private set; }

        public Transaction(Guid id, Guid fromCustomerId, Guid toCustomerId, decimal amount, DateTime @when):base(id)
        {
            FromCustomerId = fromCustomerId;
            ToCustomerId = toCustomerId;
            Amount = amount;
            When = when;
        }
    }
}
