using Metrics.Services.Domain.Entities;
using Metrics.Services.Domain.Interface;
using Metrics.Services.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metrics.Services.Infrastructure.Repositories
{
    public class IngestionRepository : Repository<IngestionEntity>, IIngestionRepository
    {
        public IngestionRepository(MetricsDbContext context) : base(context)
        {
        }
    }
}
