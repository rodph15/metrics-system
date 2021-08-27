using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.Services.Domain.Interface
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
