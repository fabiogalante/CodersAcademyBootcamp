using CodersAcademyBootcamp.Application.Account.Service;
using CodersAcademyBootcamp.Application.Account.Service.Interfaces;
using CodersAcademyBootcamp.Application.Album.Service;
using CodersAcademyBootcamp.Application.Album.Service.Interfaces;
using CodersAcademyBootcamp.Crosscutting.AzureServiceBus;
using CodersAcademyBootcamp.Crosscutting.Notification;
using CodersAcademyBootcamp.Crosscutting.Storage;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Application
{
    public static class ConfigurationModule
    {
        public static void RegisterApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CodersAcademyBootcamp.Application.ConfigurationModule).Assembly);

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IEventEnqueue, AzureServiceBusNotification>();
            services.AddScoped<IEventPublisher, EventPublisher>();

            services.AddSingleton<AzureCloudStorage>();
        }
    }
}
