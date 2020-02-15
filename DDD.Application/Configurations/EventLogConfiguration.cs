using DDD.Core.Aggregates.EventLogAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Application.Configurations
{
    public class EventLogConfiguration : BaseConfiguration<EventLog>
    {
        public override void Configure(EntityTypeBuilder<EventLog> builder)
        {
            base.Configure(builder);
            builder.ToTable("EventLogs");
            builder.PropertyEx(x => x.LogType);
            builder.PropertyEx(x => x.Type);
            builder.PropertyEx(x => x.When);
            builder.PropertyEx(x => x.Data);
        }
    }
}