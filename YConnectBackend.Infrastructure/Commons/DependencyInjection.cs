using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using YConnectBackend.Domain.Commons.Database;
using YConnectBackend.Domain.Commons.UserAggregates.Port;
using YConnectBackend.Infrastructure.Adapters.database;
using YConnectBackend.Infrastructure.Adapters.Domain.UserAggregate;

namespace YConnectBackend.Infrastructure.Commons
{
    public static class DependencyInjection
    {
        public static void InjectInfrastructure(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<,>), typeof(EfRepository<,>));
            services.InjectSpecificRepositories();
            
            Assembly infrastructureAssembly = AppDomain.CurrentDomain.Load("YConnectBackend.Infrastructure");
            
            services.AddAutoMapper(new List<Assembly>()
            {
                infrastructureAssembly
            });
        }
        public static void InjectSpecificRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}