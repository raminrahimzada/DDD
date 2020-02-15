using DDD.Core.Aggregates.CustomerAggregate;
using DDD.Core.Aggregates.TransactionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Application.Configurations
{
    public class TransactionConfiguration
        : BaseConfiguration<Transaction>
    {
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("Transactions");

            builder.PropertyEx(x => x.Amount);
            builder.PropertyEx(x => x.When);
            builder.PropertyEx(x => x.FromCustomerId);
            builder.PropertyEx(x => x.ToCustomerId);

            builder.HasOne<Customer>().WithMany().HasForeignKey(x => x.FromCustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Customer>().WithMany().HasForeignKey(x => x.ToCustomerId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}