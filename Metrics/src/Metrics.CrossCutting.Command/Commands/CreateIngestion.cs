using Metrics.CrossCutting.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.Command.Commands
{
    public class CreateIngestion : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public long SeqNum { get; set; }
        public int PickedLayers { get; set; }
        public int MachineId { get; set; }
        public int InitDate { get; set; }
        public int EndDate { get; set; }
    }
}
