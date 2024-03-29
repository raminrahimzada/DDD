﻿using DDD.Domain.Base;

namespace DDD.Domain.Aggregates.TransactionAggregate
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        void Add(Transaction transaction);
    }
}