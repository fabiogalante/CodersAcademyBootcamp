using CodersAcademyBootcamp.Crosscutting.Notification;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Domain.Account.Aggregate.Event
{
    public class ChangePasswordConfirmEvent :  CodersAcademyBootcamp.Crosscutting.Notification.Event, IEventProcessor
    {
        public const string CHANGE_PASSWORD_CONFIRMED_EVENT = "CHANGE_PASSWORD_CONFIRMED";

        public ChangePasswordConfirmEvent(string eventName, NotificationMessage notification) : base(eventName, notification)
        {

        }

        public async void Handle()
        {
            var account = JsonConvert.DeserializeObject(this.Notification.Message.Body.ToString()) as JObject;
        }
    }
}
