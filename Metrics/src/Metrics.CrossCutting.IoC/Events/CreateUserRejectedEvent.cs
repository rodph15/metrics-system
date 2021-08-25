﻿using Metrics.CrossCutting.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Events
{
    public class CreateUserRejectedEvent : IRejectedEvent
    {
        public string Email { get; }
        public string Reason { get; }
        public int Code { get; }

        protected CreateUserRejectedEvent() { 
        }

        public CreateUserRejectedEvent(string email, string reason, int code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}