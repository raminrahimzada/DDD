using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DDD.Infrastructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AppDatabaseContext>
    {
        public AppDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDatabaseContext>();
            optionsBuilder.UseSqlServer("Server=MATRIX\\SERVER17;Database=DDD;User Id=sa;Password=badimcandolmasi");

            return new AppDatabaseContext(optionsBuilder.Options);
        }
    }
}