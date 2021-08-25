using Metrics.CrossCutting.Event.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.Event.Events
{
    public class IngestionCreatedEvent : IAuthenticatedEvent
    {

        public Guid Id { get; }
        public Guid UserId { get; }
        public long SeqNum { get; }
        public int PickedLayers { get; }
        public int MachineId { get; }
        public int InitDate { get; }
        public int EndDate { get; }

        protected IngestionCreatedEvent()
        {
        }

        public IngestionCreatedEvent(Guid id, Guid userId, long seqNum, int pickedLayers, int machineId, int initDate, int endDate)
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
