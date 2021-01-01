using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Crosscutting.Notification
{
    public class EventPublisher : IEventPublisher
    {
        private IEventEnqueue EventEnqueue { get; set; }

        public EventPublisher(IEventEnqueue eventEnqueue)
        {
            this.EventEnqueue = eventEnqueue ?? throw new ArgumentNullException(nameof(eventEnqueue));
        }

        public Task Publish<T>(T @event) where T : Event
        {
            return this.EventEnqueue.Enqueue(@event);
        }

        public Task Publish<T>(T @event, Action callback, TaskContinuationOptions continuationOptions = TaskContinuationOptions.OnlyOnRanToCompletion) where T : Event
        {
            return this.EventEnqueue.Enqueue(@event, callback, continuationOptions);
        }
    }
}
