using System;

namespace Eventsourcing.Messages.Commands
{
    public class CreateCustomer : IMessage
    {
        public Guid CustomerId { get; set; }
        public Guid MessageId { get; set; }
        public string Name { get; set; }
        public Guid CorrolationId { get; set; }
        public string MessageType { get; set; }
    }
}