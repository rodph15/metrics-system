using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.CrossCutting.IoC.Interfaces
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandlerAsync(T command);
    }
}
