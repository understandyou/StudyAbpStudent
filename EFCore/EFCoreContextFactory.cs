using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Storage;

namespace EFCore
{
    public class EFCoreContextFactory : IDesignTimeDbContextFactory<EFCoreDBContext>
    {
        public EFCoreDBContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            var optionsBuilder = new DbContextOptionsBuilder<EFCoreDBContext>();
            optionsBuilder.UseMySql(configuration.GetConnectionString("Default"),p=>p.ServerVersion(new ServerVersion()));

            return new EFCoreDBContext(optionsBuilder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AbpWEbAPI/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}