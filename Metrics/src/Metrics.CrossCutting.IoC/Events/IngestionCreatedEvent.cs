using Metrics.CrossCutting.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Events
{
    public class IngestionCreatedEvent : IAuthenticatedEvent
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public long SeqNum { get; set; }
        public int PickedLayers { get; set; }
        public int MachineId { get; set; }
        public long InitDate { get; set; }

    }
}
