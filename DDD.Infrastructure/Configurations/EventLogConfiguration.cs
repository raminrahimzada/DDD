using DDD.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Configurations
{
    public class EventLogConfiguration : BaseConfiguration<EventLogDAO>
    {
        public override void Configure(EntityTypeBuilder<EventLogDAO> builder)
        {
            base.Configure(builder);
            builder.ToTable("EventLogs");
            builder.Property(x => x.LogType);
            builder.Property(x => x.Type);
            builder.Property(x => x.When);
            builder.Property(x => x.Data);
        }
    }
}