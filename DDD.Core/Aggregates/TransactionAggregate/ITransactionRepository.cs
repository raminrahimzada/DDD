﻿using DDD.Core.Base;

namespace DDD.Core.Aggregates.TransactionAggregate
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        void Add(Transaction transaction);
    }
}