using Metrics.CrossCutting.IoC.Interfaces;
using Metrics.CrossCutting.IoC.RabbitMq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Extensions
{
    public static class BusExtensions
    {
        public static IWebHost SubscribtoCommand<TCommand>(this IWebHost webHost) where TCommand : ICommand
        {
            var serviceScopeFactory = (IServiceScopeFactory)webHost
                .Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;

                var handler = services.GetRequiredService<ICommandHandler<TCommand>>();
                var busClient = services.GetRequiredService<IBusClient>();

                busClient.WithCommandHandlerAsync(handler);
            }

            return webHost;
        }

        public static IWebHost SubscribtoEvent<TEvent>(this IWebHost webHost) where TEvent : IEvent
        {
            var serviceScopeFactory = (IServiceScopeFactory)webHost
                .Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;

                var handler = services.GetRequiredService<IEventHandler<TEvent>>();
                var busClient = services.GetRequiredService<IBusClient>();

                busClient.WithEventHandlerAsync(handler);
            }

            return webHost;
        }
    }
}
