using Metrics.CrossCutting.Event.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.Event.Events
{
    public class UserCreatedEvent : IEvent
    {
        public string Name { get; }
        public string Email { get; }

        protected UserCreatedEvent()
        {
        }

        public UserCreatedEvent(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
