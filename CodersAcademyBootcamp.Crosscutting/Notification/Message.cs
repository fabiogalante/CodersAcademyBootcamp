using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Notification
{
    public class Message
    {
        public object Body { get; }

        public Message(object body)
        {
            this.Body = body ?? throw new ArgumentNullException(nameof(body));

        }
    }
}
