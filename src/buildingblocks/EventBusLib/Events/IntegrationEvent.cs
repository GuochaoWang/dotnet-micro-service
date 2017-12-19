using System;

namespace MicroServiceStructure.BuildingBlocks.EventBus.Events
{
    public class IntegrationEvent
    {
        public Guid Id { get; }
        public DateTime CreationDate { get; }

        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
    }
}