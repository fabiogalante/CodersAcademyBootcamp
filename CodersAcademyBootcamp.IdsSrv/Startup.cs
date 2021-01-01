using CodersAcademyBootcamp.IdsSrv.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.IdsSrv
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; set; }
        public IWebHostEnvironment Environment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DatabaseOptions>(Configuration.GetSection("ConnectionStrings"));

            var cert = new X509Certificate2(Path.Combine(Environment.ContentRootPath, "idssrv.pfx"), "");

            services.AddIdentityServer()
                    .AddSigningCredential(cert)
                    .AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResources())
                    .AddInMemoryApiResources(IdentityServerConfiguration.GetApiResources())
                    .AddInMemoryApiScopes(IdentityServerConfiguration.GetApiScopes())
                    .AddInMemoryClients(IdentityServerConfiguration.GetClients())
                    .AddCustomUserStore();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CodersAcademyBootcamp.IdsSrv", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodersAcademyBootcamp.IdsSrv v1"));
            }

            app.UseHttpsRedirection();

            app.UseIdentityServer();
            app.UseRouting();
            
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
