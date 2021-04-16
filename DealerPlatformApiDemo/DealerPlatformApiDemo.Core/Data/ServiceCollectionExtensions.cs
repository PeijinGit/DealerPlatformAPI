using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DealerPlatformApiDemo.Core.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContext<TContext>(
            this IServiceCollection service) where TContext : SqlHelperBase
        {
            service.AddScoped<TContext>();
            service.AddTransient<SqlHelperOptions>();
            service.AddTransient<SqlHelperBuilder>();
        }
    }
}
