using System;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CodersAcademyBootcamp.Function
{
    public class EventProcessorFunction
    {
        private readonly EventProcessor processor;

        public EventProcessorFunction(EventProcessor processor)
        {
            this.processor = processor;
        }

        [FunctionName("EventProcessor")]
        public void Run([ServiceBusTrigger("coders-academy-bootcamp-default-event-queue", Connection = "AzureServiceBusConnection")] Microsoft.Azure.ServiceBus.Message message, ILogger log)
        {
            var @event = JsonConvert.DeserializeObject<Event>(UTF8Encoding.UTF8.GetString(message.Body));
            processor.Processor(@event);
        }
    }
}
