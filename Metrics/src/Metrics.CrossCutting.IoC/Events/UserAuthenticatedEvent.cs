using Metrics.CrossCutting.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Events
{
    public class UserAuthenticatedEvent : IEvent
    {
        public string Email { get; set; }

    }
}
