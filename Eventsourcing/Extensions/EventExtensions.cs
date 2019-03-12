using Eventsourcing.Messages;
using Eventsourcing.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventsourcing.Extensions
{
    public static class EventExtensions
    {
        public static bool HasCartCreated(this IEnumerable<IEvent> events)
        {
            return events.Any(e => e.MessageType == nameof(CartCreated));
        }
    }
}
