using Metrics.CrossCutting.IoC.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit.Common;
using RawRabbit.vNext;
using RawRabbit;
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
            bus.SubscribeAsync<TCommand>(async (msg, context) => await handler.HandlerAsync(msg), cfg => cfg.WithQueue(q => q.WithName(GetExchangeName<TCommand>(name))));

        public static ISubscription WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler, string name = null) where TEvent : IEvent => 
            bus.SubscribeAsync<TEvent>(async (msg, context) => await handler.HandlerAsync(msg), cfg => cfg.WithQueue(q => q.WithName(GetExchangeName<TEvent>(name))));

        private static string GetExchangeName<T>(string name = null) => 
            string.IsNullOrWhiteSpace(name) ? $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}" : $"{name}/{typeof(T).Name}";

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("RabbitMQ");
            section.Bind(options);
            var client = BusClientFactory.CreateDefault(options);
            services.AddSingleton<IBusClient>(client);
        }
    }
}
