using DDD.Domain.Aggregates.CustomerAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DDD.Application.Configurations
{
    public class CustomerConfiguration
    : BaseConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("Customers");
            
            builder.PropertyEx(x => x.CustomerName).IsRequired();
            builder.PropertyEx(x => x.Balance).IsRequired().HasDefaultValue(0.0M);
        }
    }
}
