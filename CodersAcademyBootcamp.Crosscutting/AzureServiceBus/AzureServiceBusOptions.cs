using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Crosscutting.AzureServiceBus
{
    public class AzureServiceBusOptions
    {
        public String ConnectionString { get; set; }
        public String QueueName { get; set; }

    }
}
