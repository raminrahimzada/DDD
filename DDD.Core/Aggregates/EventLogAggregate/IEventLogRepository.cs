namespace DDD.Core.Aggregates.EventLogAggregate
{
    public interface IEventLogRepository
    {
        void Add(EventLog eventLog);
    }
}