using Metrics.CrossCutting.IoC.Interfaces;
using Metrics.CrossCutting.IoC.RabbitMq;
using Metrics.Services.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Services.Infrastructure.Extenions
{
    public static class MigrateExtensions
    {
        public static IWebHost MigrateDatabase(this IWebHost webHost)
        {
            var serviceScopeFactory = (IServiceScopeFactory)webHost
                .Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;

                var dbContext = services.GetRequiredService<MetricsDbContext>();
                if(!dbContext.Database.EnsureCreated())
                    dbContext.Database.Migrate();
            }

            return webHost;
        }

    }
}
