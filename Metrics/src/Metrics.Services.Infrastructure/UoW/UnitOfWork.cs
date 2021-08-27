using Metrics.Services.Domain.Interface;
using Metrics.Services.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.Services.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MetricsDbContext _context;

        public UnitOfWork(MetricsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
