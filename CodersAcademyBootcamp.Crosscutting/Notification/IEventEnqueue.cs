using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Crosscutting.Notification
{
    public interface IEventEnqueue
    {
        Task Enqueue(IEvent @event, Action callback = null, TaskContinuationOptions taskContinuationOptions = TaskContinuationOptions.OnlyOnRanToCompletion);
    }
}
