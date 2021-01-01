using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Function
{
    public class Event
    {
        public string EventName { get; private set; }
        public object Notification { get; private set; }

        public Event(string eventName, object notification)
        {
            this.EventName = eventName;
            this.Notification = notification;
        }
    }
}
