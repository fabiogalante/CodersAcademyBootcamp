using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Storage
{
    public class AzureStorageOptions
    {
        public string ConnectionString { get; set; }
        public string ContainerUrl { get; set; }
    }
}
