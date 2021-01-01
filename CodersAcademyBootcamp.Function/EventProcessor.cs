using Dapper;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CodersAcademyBootcamp.Function
{
    public class EventProcessor
    {
        public const string CREATE_ACCOUNT_EVENT = "CREATE-ACCOUNT";
        private readonly ConnectionOptions options;

        public EventProcessor(ConnectionOptions options)
        {
            this.options = options;
        }

        public void Processor(Event @event)
        {
            switch (@event.EventName)
            {
                case CREATE_ACCOUNT_EVENT:
                    HandleNewAccount(@event);
                    break;
            }
        }

        private void HandleNewAccount(Event @event)
        {
            var account = JsonConvert.DeserializeObject(@event.Notification.ToString()) as JObject;

            var email = account.SelectToken("Message.Body.Email").ToString();

            using (SqlConnection connection = new SqlConnection(options.CodersAcademyConnectionString))
            {
                var sql = @"UPDATE [USER]
                            SET STATUS = 1
                            WHERE Email = @Email";

                connection.ExecuteScalar(sql, new
                {
                    Email = email
                });
            }
        }
    }
}
