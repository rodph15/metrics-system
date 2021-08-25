using Metrics.CrossCutting.Command.Interfaces;
using Metrics.CrossCutting.Event.Interfaces;
using Metrics.CrossCutting.IoC.RabbitMq;
using Microsoft.AspNetCore.Hosting;
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
            var handler = (ICommandHandler<TCommand>)_webHost.Services.GetService(typeof(ICommandHandler<ICommand>));
            _busClient.WithCommandHandlerAsync(handler);

            return this;
        }

        public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
        {
            var handler = (IEventHandler<TEvent>)_webHost.Services.GetService(typeof(IEventHandler<TEvent>));
            _busClient.WithEventHandlerAsync(handler);

            return this;
        }

        public override ServiceHost Build()
        {
            return new ServiceHost(_webHost);
        }
    }
}
