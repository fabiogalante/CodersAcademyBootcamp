using CodersAcademyBootcamp.Crosscutting.Notification;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hyperion.Domain.Account.Aggregate.Event
{
    [Serializable]
    public class ForgetPasswordSendEmailEvent : CodersAcademyBootcamp.Crosscutting.Notification.Event, IEventProcessor
    {
       

        public ForgetPasswordSendEmailEvent(string eventName, NotificationMessage notification) : base(eventName, notification)
        {
            
        }

        public async void Handle()
        {

        }
    }
}
