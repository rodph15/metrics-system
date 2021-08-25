using Metrics.CrossCutting.IoC.Interfaces;
using Metrics.CrossCutting.IoC.RabbitMq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Services
{
    public class BusBuilder : BuilderBase
    {
        private readonly IWebHost _webHost;
        private IBusClient _busClient;

        public BusBuilder(IWebHost webHost, IBusClient busClient)
        {
            _webHost = webHost;
            _busClient = busClient;
        }

        public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
        {
            var serviceScopeFactory = (IServiceScopeFactory) _webHost.Services.GetService(typeof(IServiceScopeFactory));
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var handler = services.GetRequiredService<ICommandHandler<TCommand>>();

                _busClient.WithCommandHandlerAsync(handler);
            }

            return this;
        }

        public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
        {
            var serviceScopeFactory = (IServiceScopeFactory)_webHost.Services.GetService(typeof(IServiceScopeFactory));
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var handler = services.GetRequiredService<IEventHandler<TEvent>>();

                _busClient.WithEventHandlerAsync(handler);
            }

            return this;
        }

        public override ServiceHost Build()
        {
            return new ServiceHost(_webHost);
        }
    }
}
