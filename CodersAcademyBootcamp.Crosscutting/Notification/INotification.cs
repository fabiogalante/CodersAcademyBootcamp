using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Notification
{
    public interface INotification
    {
        DateTime CreationDate { get; }
        String Sender { get; }
        Dictionary<string, object> ExtraData { get; }
        Message Message { get; }
    }
}
