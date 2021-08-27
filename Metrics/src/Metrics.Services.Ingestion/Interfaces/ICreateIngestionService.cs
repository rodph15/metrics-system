using Metrics.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metrics.Services.Ingestion.Interfaces
{
    public interface ICreateIngestionService
    {
        Task Add(IngestionEntity ingestionEntity);
    }
}
