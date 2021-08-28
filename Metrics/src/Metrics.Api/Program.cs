using Metrics.CrossCutting.IoC.Commands;
using Metrics.CrossCutting.IoC.Events;
using Metrics.CrossCutting.IoC.Extensions;
using Metrics.Services.Infrastructure.Extenions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metrics.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
            .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build()
                .SubscribtoEvent<IngestionCreatedEvent>()
                .MigrateDatabase();

    }
}
