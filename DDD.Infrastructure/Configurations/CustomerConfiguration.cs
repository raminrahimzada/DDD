
using DDD.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Configurations
{
    public class CustomerConfiguration
    : BaseConfiguration<CustomerDAO>
    {
        public override void Configure(EntityTypeBuilder<CustomerDAO> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("Customers");
            
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Balance).IsRequired().HasDefaultValue(0.0M);
        }
    }
}
