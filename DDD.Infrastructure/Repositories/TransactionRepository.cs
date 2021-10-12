using DDD.Domain.Aggregates.TransactionAggregate;

namespace DDD.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDatabaseContext _dbContext;
        public TransactionRepository(AppDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction.ToDAO());
        }
    }
}