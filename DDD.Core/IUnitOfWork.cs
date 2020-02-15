﻿using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Core.Aggregates.CustomerAggregate;
using DDD.Core.Aggregates.TransactionAggregate;

namespace DDD.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepo { get; }
        ITransactionRepository TransactionRepo { get; set; }
        
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}