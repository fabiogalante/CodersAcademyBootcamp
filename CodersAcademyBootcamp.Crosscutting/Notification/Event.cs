using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Notification
{
    public class Event : IEvent
    {
        public string EventName { get; private set; }
        public INotification Notification { get; private set; }

        public Event(string eventName, NotificationMessage notification)
        {
            this.EventName = eventName;
            this.Notification = notification as NotificationMessage;
        }
    }
}
