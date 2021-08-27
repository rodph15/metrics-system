using Metrics.Services.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metrics.Api.Interfaces
{
    public interface IIngestionReportService
    {
        Task<MetricCalculationDto> MetricCalculation();
    }
}
