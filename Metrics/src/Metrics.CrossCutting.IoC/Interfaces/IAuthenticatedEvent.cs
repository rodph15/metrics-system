using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Interfaces
{
    public interface IAuthenticatedEvent : IEvent
    {
        public Guid UserId { get; }
    }
}
