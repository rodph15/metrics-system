using Metrics.CrossCutting.IoC.Interfaces;
using Metrics.CrossCutting.IoC.Commands;
using Metrics.CrossCutting.IoC.Events;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.CrossCutting.IoC.Handlers
{
    public class CreateIngestionHandler : ICommandHandler<CreateIngestion>
    {

        private readonly IBusClient _busClient;

        public CreateIngestionHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task HandlerAsync(CreateIngestion command)
        {
            Console.WriteLine($"Creating ingestion : {command.Id}");
            await _busClient.PublishAsync(new IngestionCreatedEvent(command.Id, command.UserId, command.SeqNum, command.PickedLayers, command.MachineId, command.InitDate, command.EndDate));
        }
    }
}
