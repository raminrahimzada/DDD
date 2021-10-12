using System.Linq;
using System.Threading.Tasks;
using DDD.Domain;
using DDD.Domain.Base;

namespace DDD.Infrastructure
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IGenericBus bus, AppDatabaseContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<IAggregateRoot>()
                .ToArray();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DequeueUncommittedEvents())
                .ToList();
            foreach (var domainEvent in domainEvents)
                await bus.Publish(domainEvent);
        }
    }
}