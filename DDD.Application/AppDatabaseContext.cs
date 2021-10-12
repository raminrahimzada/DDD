//using System.Threading;
//using System.Threading.Tasks;
//using DDD.Application.Configurations;

//using DDD.Domain;
//using DDD.Domain.Aggregates.CustomerAggregate;
//using DDD.Domain.Aggregates.EventLogAggregate;
//using DDD.Domain.Aggregates.TransactionAggregate;
//using Microsoft.EntityFrameworkCore;

//namespace DDD.Application
//{
//    public class AppDatabaseContext : DbContext
//    {
//        private readonly IGenericBus _bus;

//        public AppDatabaseContext()
//        {

//        }

//        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options) { }

//        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options, IGenericBus bus) : base(options)
//        {
//            _bus = bus;
//        }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
//            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
//            modelBuilder.ApplyConfiguration(new EventLogConfiguration());

//            base.OnModelCreating(modelBuilder);
//        }

//        public DbSet<Customer> Customers { get; set; }
//        public DbSet<Transaction> Transactions { get; set; }
//        public DbSet<EventLog> EventLogs { get; set; }

//        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
//        {
//            var result = await base.SaveChangesAsync(cancellationToken);
//            if (_bus != null)
//            {
//                await _bus.DispatchDomainEventsAsync(this);
//            }
//            return result;
//        }
//    }
//}