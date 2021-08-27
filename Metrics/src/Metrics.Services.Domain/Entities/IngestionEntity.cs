using Metrics.CrossCutting.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Services.Domain.Entities
{
    public class IngestionEntity
    {
        public Guid Id { get; set; }
        public long SeqNum { get; set; }
        public int PickedLayers { get; set; }
        public int MachineId { get; set; }
        public long InitDate { get; set; }
        public long EndDate { get; set; }
    }
}
