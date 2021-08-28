using AutoMapper.Configuration;
using Metrics.CrossCutting.IoC.Commands;
using Metrics.CrossCutting.IoC.Events;
using Metrics.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metrics.CrossCutting.Configuration.Map
{
    public class MappingProfile : MapperConfigurationExpression
    {
        public MappingProfile()
        {

            CreateMap<CreateIngestion, IngestionEntity>()
                .ForMember(x => x.Id, m => m.Ignore())
                .ForMember(x => x.EndDate, m => m.MapFrom( o => DateTimeOffset.UtcNow.ToUnixTimeSeconds()));

            CreateMap<IngestionCreatedEvent, IngestionEntity>()
                .ForMember(x => x.Id, m => m.Ignore())
                .ForMember(x => x.EndDate, m => m.MapFrom(o => DateTimeOffset.UtcNow.ToUnixTimeSeconds()));

            CreateMap<IngestionCreatedEvent, CreateIngestion>().ReverseMap();
        }
    }
}
