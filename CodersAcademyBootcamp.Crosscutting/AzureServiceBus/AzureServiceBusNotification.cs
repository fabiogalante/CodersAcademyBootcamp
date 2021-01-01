using CodersAcademyBootcamp.Crosscutting.Notification;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Crosscutting.AzureServiceBus
{
    public class AzureServiceBusNotification : IEventEnqueue, IDisposable
    {
        private string QueueName { get; set; }

        private QueueClient QueueNotification { get; set; }

        private AzureServiceBusOptions Options { get; set; }

        public AzureServiceBusNotification(IOptions<AzureServiceBusOptions> options)
        {
            this.Options = options.Value;
            this.Setup();
        }

        public AzureServiceBusNotification(string queueName) : base()
        {
            this.QueueName = queueName ?? throw new ArgumentNullException(nameof(queueName));
        }


        #region Private Methods

        private void Setup()
        {
            string configurationSettings = this.Options.ConnectionString;
            this.QueueName = this.Options.QueueName;

            this.QueueNotification = new QueueClient(configurationSettings, this.QueueName);
            
        }

        public async Task Enqueue(IEvent @event, Action callback = null, TaskContinuationOptions taskContinuationOptions = TaskContinuationOptions.OnlyOnRanToCompletion)
        {

            Microsoft.Azure.ServiceBus.Message message = new Microsoft.Azure.ServiceBus.Message(UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            })));

            message.MessageId = Guid.NewGuid().ToString();
            message.ContentType = "application/json";

            if (callback != null)
            {
                await QueueNotification.SendAsync(message).ContinueWith((t, o) =>
                {
                    callback?.Invoke();
                }, taskContinuationOptions);
            }
            else
            {
                await QueueNotification.SendAsync(message);
            }
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (!this.QueueNotification.IsClosedOrClosing)
                        this.QueueNotification.CloseAsync().Wait();
                }

                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}
