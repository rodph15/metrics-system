using Metrics.CrossCutting.Event.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.Event.Events
{
    public class UserAuthenticatedEvent : IEvent
    {
        public string Email { get; }

        protected UserAuthenticatedEvent()
        {
        }

        public UserAuthenticatedEvent(string email)
        {
            Email = email;
        }
    }
}
