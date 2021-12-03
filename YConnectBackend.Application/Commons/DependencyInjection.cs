using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YConnectBackend.Domain.Commons;
using YConnectBackend.Infrastructure.Commons;



namespace Yconnect_backend.Commons
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.InjectInfrastructure();
        }
    }
}