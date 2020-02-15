using System.IO;
using DDD.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DDD.WebApi
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AppDatabaseContext>
    {
        public AppDatabaseContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDatabaseContext>();
            
            var connectionString = config["ConnectionString"];
            
            optionsBuilder.UseSqlServer(connectionString);


            return new AppDatabaseContext(optionsBuilder.Options);
        }
    }
}