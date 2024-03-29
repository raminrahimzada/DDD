﻿using System.Threading;
using System.Threading.Tasks;
using DDD.Domain;
using DDD.Infrastructure.Configurations;
using DDD.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure
{
    public class AppDatabaseContext : DbContext
    {
        private readonly IGenericBus _bus;

        public AppDatabaseContext()
        {

        }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options) { }

        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options, IGenericBus bus) : base(options)
        {
            _bus = bus;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new EventLogConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CustomerDAO> Customers { get; set; }
        public DbSet<TransactionDAO> Transactions { get; set; }
        public DbSet<EventLogDAO> EventLogs { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            if (_bus != null)
            {
                await _bus.DispatchDomainEventsAsync(this);
            }
            return result;
        }
    }
}