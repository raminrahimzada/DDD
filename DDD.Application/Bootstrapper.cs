using System;
using DDD.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Application
{
    public static class Bootstrapper
    {
        public static void Register(IServiceCollection services, Action<DbContextOptionsBuilder> dbContextOptions)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMediatR(typeof(Bootstrapper).Assembly);
            services.AddDbContext<AppDatabaseContext>(dbContextOptions);
        }
    }
}