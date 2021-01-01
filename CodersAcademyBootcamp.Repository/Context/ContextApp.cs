using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodersAcademyBootcamp.Repository.Context
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextApp).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            ILoggerFactory Logger = LoggerFactory.Create(x => x.AddConsole());
            optionsBuilder.UseLoggerFactory(Logger);

            base.OnConfiguring(optionsBuilder);
        }





    }
}
