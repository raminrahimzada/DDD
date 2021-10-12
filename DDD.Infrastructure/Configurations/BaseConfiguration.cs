using DDD.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Infrastructure.Configurations
{
    public class BaseConfiguration<TDAO>
        : IEntityTypeConfiguration<TDAO> where TDAO : BaseDAO
    {
        public virtual void Configure(EntityTypeBuilder<TDAO> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}