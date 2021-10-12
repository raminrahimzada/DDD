using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Infrastructure
{
    public static class Bootstrapper
    {
        public static void Register(IServiceCollection services, Action<DbContextOptionsBuilder> dbContextOptions)
        {
            services.AddDbContext<AppDatabaseContext>(dbContextOptions);
        }
    }
}