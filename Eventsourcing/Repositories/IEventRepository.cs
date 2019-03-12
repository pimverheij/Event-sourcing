using Eventsourcing.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventsourcing.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<IEvent>> GetEventsAsync(Guid corrolationId);
        Task SaveEventAsync(IEvent @event);
    }

    public class InMemoryEvenRepository : IEventRepository
    {
        private static List<IEvent> _events = new List<IEvent>();

        public Task<IEnumerable<IEvent>> GetEventsAsync(Guid corrolationId)
        {
            return Task.Run<IEnumerable<IEvent>>(() =>
            {
                return _events.Where(e => e.CorrolationId == corrolationId);
            });
        }

        public Task SaveEventAsync(IEvent @event)
        {
            return Task.Run(() =>
            {
                _events.Add(@event);
            });
        }
    }
}
