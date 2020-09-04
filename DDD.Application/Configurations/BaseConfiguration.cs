using DDD.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Application.Configurations
{
    public class BaseConfiguration<TEntity>
        : IEntityTypeConfiguration<TEntity> where TEntity : class, IAggregateRoot
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}