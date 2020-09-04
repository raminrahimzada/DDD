namespace DDD.Domain.Aggregates.EventLogAggregate
{
    public interface IEventLogRepository
    {
        void Add(EventLog eventLog);
    }
}