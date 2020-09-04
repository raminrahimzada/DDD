using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Application
{
    public static class EntityTypeBuilderExtensions
    {
        public static PropertyBuilder<TProperty> PropertyEx<TEntity,TProperty>(
            this EntityTypeBuilder<TEntity> builder,
            [NotNull] Expression<Func<TEntity, TProperty>> propertyExpression) where TEntity : class
        //where TEntity : Entity<Id>
        {
            return builder.Property(propertyExpression)
                .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
        }
    }
}