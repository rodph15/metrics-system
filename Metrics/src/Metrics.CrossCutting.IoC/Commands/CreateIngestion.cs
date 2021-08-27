using Metrics.CrossCutting.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Commands
{
    public class CreateIngestion : ICommand
    {
        public long SeqNum { get; set; }
        public int PickedLayers { get; set; }
        public int MachineId { get; set; }
        public long InitDate { get; set; }

    }
}
