using Metrics.CrossCutting.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Events
{
    public class IngestionCreatedEvent : IAuthenticatedEvent
    {

        public Guid Id { get;  }
        public Guid UserId { get; }
        public long SeqNum { get; }
        public int PickedLayers { get; }
        public int MachineId { get; }
        public long InitDate { get; }
        public long EndDate { get; }

        public IngestionCreatedEvent()
        {
        }

        public IngestionCreatedEvent(Guid id, Guid userId, long seqNum, int pickedLayers, int machineId, long initDate, long endDate)
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
