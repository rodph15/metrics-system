using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.Event.Interfaces
{
    public interface IRejectedEvent : IEvent
    {
        public string Reason { get; }
        public int Code { get; }
    }
}
