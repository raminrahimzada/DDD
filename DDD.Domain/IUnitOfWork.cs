using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Core.Aggregates.CustomerAggregate;
using DDD.Core.Aggregates.EventLogAggregate;
using DDD.Core.Aggregates.TransactionAggregate;

namespace DDD.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepo { get; }
        ITransactionRepository TransactionRepo { get;}
        IEventLogRepository EventLogRepo { get; }

        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}