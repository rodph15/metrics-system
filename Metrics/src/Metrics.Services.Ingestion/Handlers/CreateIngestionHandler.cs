using Metrics.CrossCutting.IoC.Interfaces;
using Metrics.CrossCutting.IoC.Commands;
using Metrics.CrossCutting.IoC.Events;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Metrics.Services.Ingestion.Interfaces;
using Metrics.CrossCutting.ExceptionManagement.Exceptions;
using AutoMapper;
using Metrics.Services.Domain.Entities;
using Metrics.Services.Domain.Interface;

namespace Metrics.Services.Ingestion.Handlers
{
    public class CreateIngestionHandler : ICommandHandler<CreateIngestion>
    {

        private readonly IBusClient _busClient;
        private readonly ICreateIngestionService _createIngestionService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateIngestionHandler(IBusClient busClient, ICreateIngestionService createIngestionService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _busClient = busClient;
            _createIngestionService = createIngestionService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task HandlerAsync(CreateIngestion command)
        {
            try
            {
                var ingestionEntity = _mapper.Map<IngestionEntity>(command);

                _createIngestionService.Add(ingestionEntity);

                Console.WriteLine($"Creating ingestion : {command.MachineId}");

                await _busClient.PublishAsync(new IngestionCreatedEvent());

                if(!await _unitOfWork.CommitAsync())
                {
                    throw new IngestionNotCreatedException();
                }
                    
            }
            catch(Exception ex)
            {
                Console.WriteLine($"logging : {ex.Message}");
            }
        }
    }
}
