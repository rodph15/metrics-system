using Metrics.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metrics.Services.Domain.Interface
{
    public interface IIngestionRepository : IRepository<IngestionEntity>
    {
        
    }
}
