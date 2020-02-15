using System;
using System.Collections.Generic;
using System.Text;
using DDD.Core.Base;

namespace DDD.Core.Aggregates.EventLogAggregate
{
    public class EventLog:Entity,IAggregateRoot
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

        public EventLog(EventLogTypes logType, string type, DateTime @when, string data)
        {
            LogType = logType;
            Type = type;
            When = when;
            Data = data;
        }
    }
}
