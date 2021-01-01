using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Notification
{
    [Serializable]
    public class NotificationMessage : INotification
    {
        public DateTime CreationDate { get; private set; }

        public string Sender { get; private set; }

        public Dictionary<string, object> ExtraData { get; private set; }

        public Message Message { get; private set; }

        public NotificationMessage(string sender, Message message, Dictionary<string, object> extraData = null)
        {
            this.CreationDate = DateTime.Now;
            this.Sender = sender;
            this.Message = message;
            this.ExtraData = extraData;
        }
    }
}
