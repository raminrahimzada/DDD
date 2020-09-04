using System;
using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Aggregates.CustomerAggregate;
using DDD.Domain.Aggregates.EventLogAggregate;
using DDD.Domain.Aggregates.TransactionAggregate;

namespace DDD.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepo { get; }
        ITransactionRepository TransactionRepo { get;}
        IEventLogRepository EventLogRepo { get; }

        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}