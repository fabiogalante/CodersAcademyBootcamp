using AutoMapper;
using CodersAcademyBootcamp.API.Filter;
using CodersAcademyBootcamp.Application;
using CodersAcademyBootcamp.Crosscutting.AzureServiceBus;
using CodersAcademyBootcamp.Crosscutting.Storage;
using CodersAcademyBootcamp.Repository;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.API
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
            
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
              .AddIdentityServerAuthentication(options =>
              {
                  options.Authority = Configuration["AuthenticateSetting:Authority"];
                  options.ApiName = Configuration["AuthenticateSetting:ApiName"]; 
                  options.ApiSecret = Configuration["AuthenticateSetting:ApiSecret"];
                  options.RequireHttpsMetadata = true;
              });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CodersAcademyRole", p =>
                {
                    p.RequireClaim("role", "coders-academy-user");
                });
            });

            services.AddControllers(o =>
            {
                o.Filters.Add(new HttpResponseExceptionFilter());
            }).ConfigureApiBehaviorOptions(c =>
            {
                c.SuppressModelStateInvalidFilter = true;
            });


            services.RegisterRepository(this.Configuration.GetConnectionString("BootcampConnection"));
            services.RegisterApplication();

            services.Configure<AzureStorageOptions>(Configuration.GetSection("Microsoft.Storage"));
            services.Configure<AzureServiceBusOptions>(Configuration.GetSection("Microsoft.ServiceBus"));

            services.AddAutoMapper(typeof(Startup).Assembly,
                                   typeof(CodersAcademyBootcamp.Application.ConfigurationModule).Assembly);



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CodersAcademyBootcamp.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodersAcademyBootcamp.API v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
