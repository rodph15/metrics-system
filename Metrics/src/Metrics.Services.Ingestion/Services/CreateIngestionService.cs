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

        public async Task<bool> Add(IngestionEntity ingestionEntity)
        {
            await _ingestionRepository.Save(ingestionEntity);
            var result = await _unitOfWork.CommitAsync();
            if (!result)
            {
                throw new IngestionNotCreatedException();
            }

            return result;
        }

        
    }
}
