using System.Linq;
using System.Threading.Tasks;
using DDD.Core.Base;
using MediatR;

namespace DDD.Application
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this ICustomMediator mediator, AppDatabaseContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
                .ToArray();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}