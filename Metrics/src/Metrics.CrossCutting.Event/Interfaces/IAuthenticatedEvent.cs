using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.Event.Interfaces
{
    public interface IAuthenticatedEvent : IEvent
    {
        public Guid UserId { get; }
    }
}
