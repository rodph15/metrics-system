using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.CrossCutting.IoC.Interfaces
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandlerAsync(T @event);
    }
}
