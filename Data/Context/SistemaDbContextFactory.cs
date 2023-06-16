using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class SistemaDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {

            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(ConfigurationExtensions.GetConnectionString(configuration, "Default"), b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));

            //optionsBuilder.UseSqlServer(ConfigurationExtensions.GetConnectionString(configuration, "defaultconnection"),
            //    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
