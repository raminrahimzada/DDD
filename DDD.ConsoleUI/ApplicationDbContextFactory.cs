using DDD.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DDD.ConsoleUI
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AppDatabaseContext>
    {
        public AppDatabaseContext CreateDbContext(params string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDatabaseContext>();
            optionsBuilder.UseSqlServer("Server=MATRIX\\SERVER17;Database=DDD;User Id=sa;Password=badimcandolmasi");

            return new AppDatabaseContext(optionsBuilder.Options);
        }
    }
}