using System;
using System.Reflection;
using DDD.Application.Base;

using DDD.Domain;
using DDD.Infrastructure;
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

            
            services.AddMediatR(typeof(Bootstrapper).GetTypeInfo().Assembly);
            services.AddScoped<IMediator, Mediator>();
            services.AddDbContext<AppDatabaseContext>(dbContextOptions);
            services.AddScoped<IGenericBus, MediatrBus>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}