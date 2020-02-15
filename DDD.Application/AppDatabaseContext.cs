using System.Threading;
using System.Threading.Tasks;
using DDD.Application.Configurations;
using DDD.Core.Aggregates.CustomerAggregate;
using DDD.Core.Aggregates.EventLogAggregate;
using DDD.Core.Aggregates.TransactionAggregate;
using Microsoft.EntityFrameworkCore;

namespace DDD.Application
{
    public class AppDatabaseContext : DbContext
    {
        private readonly ICustomMediator _mediator;

        public AppDatabaseContext()
        {
            
        }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options) { }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options, ICustomMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new EventLogConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }
        public override  async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result =await base.SaveChangesAsync(cancellationToken);
            await _mediator.DispatchDomainEventsAsync(this);
            return result;
        }
    }
}