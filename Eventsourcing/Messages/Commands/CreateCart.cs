using System;

namespace Eventsourcing.Messages.Commands
{
    public class AddProduct : IMessage
    {
        public Guid MessageId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CorrolationId { get; set; }
        public Guid ProductId { get; set; }
        public string MessageType { get; set; }
    }
}
