using Metrics.CrossCutting.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Commands
{
    public class CreateIngestion : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public long SeqNum { get; set; }
        public int PickedLayers { get; set; }
        public int MachineId { get; set; }
        public long InitDate { get; set; }
        public long EndDate { get; set; }

        public CreateIngestion()
        {
        }

        public CreateIngestion(Guid id, Guid userId, long seqNum, int pickedLayers, int machineId, long initDate, long endDate)
        {
            Id = id;
            UserId = userId;
            SeqNum = seqNum;
            PickedLayers = pickedLayers;
            MachineId = machineId;
            InitDate = initDate;
            EndDate = endDate;
        }
    }
}
