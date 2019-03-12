using System;

namespace Eventsourcing.Messages.Events
{
    public class CustomerCreated : IEvent
    {
        public Guid CustomerId { get; set; }
        public Guid MessageId { get; set; }
        public string Name { get; set; }
        public Guid CorrolationId { get; set; }
        public string MessageType { get; set; }

        public CustomerCreated()
        {
            MessageType = nameof(CustomerCreated);
        }
    }
}
