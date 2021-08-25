using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.CrossCutting.Event.Interfaces
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
