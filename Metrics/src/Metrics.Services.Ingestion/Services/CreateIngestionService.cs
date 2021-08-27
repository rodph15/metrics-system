using AutoMapper;
using Metrics.Services.Domain.Entities;
using Metrics.Services.Domain.Interface;
using Metrics.Services.Ingestion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metrics.Services.Ingestion.Services
{
    public class CreateIngestionService : ICreateIngestionService
    {

        private readonly IIngestionRepository _ingestionRepository;
        public CreateIngestionService(IIngestionRepository ingestionRepository)
        {
            _ingestionRepository = ingestionRepository;
        }

        public void Add(IngestionEntity ingestionEntity)
        {
            _ingestionRepository.Save(ingestionEntity);
        }

        
    }
}
