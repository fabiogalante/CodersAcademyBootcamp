using CodersAcademyBootcamp.Domain.Account.Repository;
using CodersAcademyBootcamp.Domain.Album.Repository;
using CodersAcademyBootcamp.Repository.Context;
using CodersAcademyBootcamp.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Repository
{
    public static class ConfigurationModule
    {
        public static void RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ContextApp>(c =>
            {
                c.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(UnitOfWork<>));
            
         
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();

        }
    }
}
