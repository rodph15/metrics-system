using Metrics.CrossCutting.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Events
{
    public class UserCreatedEvent : IEvent
    {
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
