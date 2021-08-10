using System;
using System.Threading.Tasks;
using EFCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Data;

namespace InitDataMigration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<InitModule>(options =>
            {
                options.UseAutofac();
                //options.Services.AddLogging(c => c.AddSerilog());
            }))
            {
                application.Initialize();

                var context = application
                    .ServiceProvider
                    .GetService<DataSeedContext>();

                await application
                    .ServiceProvider
                    .GetRequiredService<InitDataService>()
                    .SeedAsync(context);

                application.Shutdown();
                
                //_hostApplicationLifetime.StopApplication();
            }
            Console.Read();
        }
    }
}
