using DDD.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Configurations
{
    public class TransactionConfiguration
        : BaseConfiguration<TransactionDAO>
    {
        public override void Configure(EntityTypeBuilder<TransactionDAO> builder)
        {
            base.Configure(builder);
            
            builder.ToTable("Transactions");

            builder.Property(x => x.Amount);
            builder.Property(x => x.When);

            builder.HasOne(x=>x.FromCustomer).WithMany().HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.ToCustomer).WithMany().HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}