using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Crosscutting.Notification
{
    public interface IEventPublisher
    {
        Task Publish<T>(T @event) where T : Event;

        Task Publish<T>(T @event, Action callback, TaskContinuationOptions continuationOptions) where T : Event;
    }
}
