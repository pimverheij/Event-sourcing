using System;

namespace Eventsourcing.Messages.Events
{
    public class CartCreated : IEvent
    {
        public Guid CartId { get; set; }
        public Guid MessageId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CorrolationId { get; set; }
        public string MessageType { get; set; }

        public CartCreated()
        {
            MessageType = nameof(CartCreated);
        }
    }
}
