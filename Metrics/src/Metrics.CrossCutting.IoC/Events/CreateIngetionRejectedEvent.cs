using Metrics.CrossCutting.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Events
{
    public class CreateIngetionRejectedEvent : IRejectedEvent
    {
        public int MachineId { get; set; }
        public string Reason { get; set; }
        public int Code { get; set; }


    }
}
