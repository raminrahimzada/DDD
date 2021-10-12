using System;

namespace DDD.Infrastructure.Models
{
    public class EventLogDAO : BaseDAO
    {
        public byte LogType { get; set; }
        public string Type { get; set; }
        public DateTime When { get; set; }
        public string Data { get; set; }
    }
}