
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(CodersAcademyBootcamp.Function.Startup))]

namespace CodersAcademyBootcamp.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            builder.Services.AddScoped<EventProcessor>();


            builder.Services.AddSingleton<ConnectionOptions>((c) =>
            {
                return new ConnectionOptions()
                {
                    CodersAcademyConnectionString = Environment.GetEnvironmentVariable("CodersAcademyConnectionString")
                };
            });
        }
    }
}
