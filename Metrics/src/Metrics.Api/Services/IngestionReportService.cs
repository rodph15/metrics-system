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
        
        public async Task<LayersRateDto> LayersRate()
        {
            var velocity = (await StackingVelocity()).Velocity;

            var rate = await _ingestionRepository.SumItem(x => x.PickedLayers) / velocity;

            return new LayersRateDto { Rate = rate };
        }

        public async Task<StackingVelocityDto> StackingVelocity()
        {
            var first = (await _ingestionRepository.FirstItem(x => x.EndDate)).EndDate;
            var last = (await _ingestionRepository.LastItem(x => x.EndDate)).EndDate;
            var secondsBettwen = last - first;

            TimeSpan time = TimeSpan.FromSeconds(secondsBettwen);
            DateTime dateTime = DateTime.Today.Add(time);

            var minutes = int.Parse(dateTime.ToString("mm"));

            var velocity = await _ingestionRepository.SumItem(x => x.PickedLayers) / minutes;

            return new StackingVelocityDto { Velocity = velocity };

        }
    }
}
