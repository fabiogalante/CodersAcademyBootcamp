using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Notification
{
    public interface IEvent
    {
        String EventName { get; }
        INotification Notification { get; }
    }
}
