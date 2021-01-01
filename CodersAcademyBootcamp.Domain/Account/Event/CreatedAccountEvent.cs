using CodersAcademyBootcamp.Crosscutting.Notification;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Domain.Account.Aggregate.Event
{
    [Serializable]
    public class CreatedAccountEvent : CodersAcademyBootcamp.Crosscutting.Notification.Event, IEventProcessor
    {

        public const string CREATE_ACCOUNT_EVENT = "CREATE-ACCOUNT";

        public CreatedAccountEvent(string eventName, NotificationMessage notification) : base(eventName, notification)
        {

        }

        public async void Handle()
        {
            var account = JsonConvert.DeserializeObject(this.Notification.Message.Body.ToString()) as JObject;

        }
    }
}
