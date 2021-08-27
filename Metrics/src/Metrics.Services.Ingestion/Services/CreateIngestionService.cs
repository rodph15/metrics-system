using AutoMapper;
using Metrics.CrossCutting.ExceptionManagement.Exceptions;
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
        private readonly IUnitOfWork _unitOfWork;

        public CreateIngestionService(IIngestionRepository ingestionRepository, IUnitOfWork unitOfWork)
        {
            _ingestionRepository = ingestionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(IngestionEntity ingestionEntity)
        {
            _ingestionRepository.Save(ingestionEntity);
            if(!await _unitOfWork.CommitAsync())
            {
                throw new IngestionNotCreatedException();
            }
        }

        
    }
}
