using AutoMapper;
using Metrics.CrossCutting.IoC.Events;
using Metrics.CrossCutting.IoC.Interfaces;
using Metrics.Services.Domain.Entities;
using Metrics.Services.Ingestion.Interfaces;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.Api.Handlers
{
    public class IngestionCreatedHandler : IEventHandler<IngestionCreatedEvent>
    {
        private readonly IBusClient _busClient;
        private readonly ICreateIngestionService _createIngestionService;
        private readonly IMapper _mapper;

        public IngestionCreatedHandler(IBusClient busClient, ICreateIngestionService createIngestionService, IMapper mapper)
        {
            _busClient = busClient;
            _createIngestionService = createIngestionService;
            _mapper = mapper;
        }

        public async Task HandlerAsync(IngestionCreatedEvent @event)
        {
            try
            {
                var ingestionEntity = _mapper.Map<IngestionEntity>(@event);

                await _createIngestionService.Add(ingestionEntity);

            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateIngetionRejectedEvent());
                Console.WriteLine($"logging : {ex.Message}");
            }
        }
    }
}
