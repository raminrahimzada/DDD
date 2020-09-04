using System;
using DDD.Core.Base;

namespace DDD.Core.Aggregates.EventLogAggregate
{
    public class EventLog: AggregateRoot
    {
        public enum EventLogTypes:byte
        {
            Event=1,
            Command=2,
            Query=3,
        }
        public EventLogTypes LogType { get;}
        public string Type { get;}
        public DateTime When { get;  }
        public string Data { get;  }

        public EventLog(Guid id,EventLogTypes logType, string type, DateTime @when, string data):base(id)
        {
            LogType = logType;
            Type = type;
            When = when;
            Data = data;
        }
    }
}
