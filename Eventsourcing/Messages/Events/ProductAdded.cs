using System;

namespace Eventsourcing.Messages.Events
{
    public class ProductAdded : IEvent
    {
        public Guid MessageId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Guid CorrolationId { get; set; }
        public string MessageType { get; set; }

        public ProductAdded()
        {
            MessageType = nameof(ProductAdded);
        }
    }
}
