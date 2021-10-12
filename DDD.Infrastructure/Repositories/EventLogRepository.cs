using DDD.Domain.Aggregates.EventLogAggregate;

namespace DDD.Infrastructure.Repositories
{
    public class EventLogRepository : IEventLogRepository
    {
        private readonly AppDatabaseContext _dbContext;

        public EventLogRepository(AppDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(EventLog eventLog)
        {
            _dbContext.EventLogs.Add(eventLog.ToDAO());
        }
    }
}