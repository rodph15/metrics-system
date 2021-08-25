using Metrics.CrossCutting.Command.Interfaces;
using Metrics.CrossCutting.Event.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.CrossCutting.IoC.RabbitMq
{
    public static class RabbitMqExtensions
    {
        public static ISubscription WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler, string name = null) where TCommand : ICommand => 
            bus.SubscribeAsync<TCommand>(async (msg, context) => await handler.HandleAsync(msg), cfg => cfg.WithQueue(q => q.WithName(GetExchangeName<TCommand>(name))));

        public static ISubscription WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler, string name = null) where TEvent : IEvent => 
            bus.SubscribeAsync<TEvent>(async (msg, context) => await handler.HandleAsync(msg), cfg => cfg.WithQueue(q => q.WithName(GetExchangeName<TEvent>(name))));

        private static string GetExchangeName<T>(string name = null) => 
            string.IsNullOrWhiteSpace(name) ? $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}" : $"{name}/{typeof(T).Name}";
    }
}
