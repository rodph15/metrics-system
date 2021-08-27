using Metrics.CrossCutting.IoC.Events;
using Metrics.CrossCutting.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.Services.Ingestion.Handlers
{
    public class IngestionCreatedHandler : IEventHandler<IngestionCreatedEvent>
    {
        public async Task HandlerAsync(IngestionCreatedEvent @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Ingestion task finished with id: {@event.Id}");
        }
    }
}
