using System;
using DDD.Core.Aggregates.EventLogAggregate;
using DDD.Core.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DDD.Application
{
    public interface IEventStore
    {
        void AddEvent(IDomainEvent @event);
        void AddCommand(ICommand command);
        void AddQuery<TResponse>(IQuery<TResponse> query);
    }

    public class EventStore : IEventStore
    {
        private readonly IConfiguration _configuration;

        public EventStore(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private void Add(EventLog eventLog)
        {
            //TODO this should be saved in noSQL db
            //for now we are saving it to sql server also 

            var connectionString = _configuration.GetConnectionString("AppDatabaseContext");
            var optionsBuilder = new DbContextOptionsBuilder<AppDatabaseContext>();
            optionsBuilder.UseSqlServer(connectionString);
            
            using (var ctx=new AppDatabaseContext(optionsBuilder.Options))
            {
                ctx.EventLogs.Add(eventLog);
                ctx.SaveChanges();
            }
        }
        public void AddEvent(IDomainEvent @event)
        {
            var e = new EventLog(EventLog.EventLogTypes.Event,@event.GetType().FullName, DateTime.Now,
                Newtonsoft.Json.JsonConvert.SerializeObject(@event));
            Add(e);
        }

        public void AddCommand(ICommand command)
        {
            var e = new EventLog(EventLog.EventLogTypes.Command, command.GetType().FullName, DateTime.Now,
                Newtonsoft.Json.JsonConvert.SerializeObject(command));
            Add(e);
        }

        public void AddQuery<TResponse>(IQuery<TResponse> query)
        {
            var e = new EventLog(EventLog.EventLogTypes.Query, query.GetType().FullName, DateTime.Now,
                Newtonsoft.Json.JsonConvert.SerializeObject(query));
            Add(e);
        }
    }
}