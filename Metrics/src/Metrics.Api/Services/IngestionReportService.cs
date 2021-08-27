using AutoMapper;
using Metrics.Api.Interfaces;
using Metrics.Services.Domain.Dto;
using Metrics.Services.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metrics.Api.Services
{
    public class IngestionReportService : IIngestionReportService
    {
        private readonly IMapper _mapper;
        private readonly IIngestionRepository _ingestionRepository;

        public IngestionReportService(IMapper mapper, IIngestionRepository ingestionRepository)
        {
            _mapper = mapper;
            _ingestionRepository = ingestionRepository;
        }

        public async Task<MetricCalculationDto> MetricCalculation()
        {
            var metrics = await _ingestionRepository.GetAll();

            return new MetricCalculationDto();
        }
    }
}
