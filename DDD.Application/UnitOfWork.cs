using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Repositories;
using DDD.Core;
using DDD.Core.Aggregates.CustomerAggregate;
using DDD.Core.Aggregates.EventLogAggregate;
using DDD.Core.Aggregates.TransactionAggregate;

namespace DDD.Application
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepo { get; }
        public ITransactionRepository TransactionRepo { get; set; }
        public IEventLogRepository EventLogRepo { get; set; }


        private readonly AppDatabaseContext _dbContext;


        public UnitOfWork(AppDatabaseContext dbContext)
        {
            _dbContext = dbContext;
            CustomerRepo=new CustomerRepository(_dbContext);
            TransactionRepo = new TransactionRepository(dbContext);
            EventLogRepo = new EventLogRepository(dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}