using System;

namespace Eventsourcing.Messages
{
    public interface IMessage
    {
        Guid MessageId { get; set; }
        Guid CorrolationId { get; set; }
        string MessageType { get; set; }
    }
}
