using Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EFCore
{
    [DependsOn(typeof(AbpIdentityEntityFrameworkCoreModule)
    ,typeof(DomainModule),typeof(AbpEntityFrameworkCoreMySQLModule)
    )]//AbpIdentityEntityFrameworkCoreModule这个注解是包含了AbpEntityFrameworkCoreModule的
    public class EFCoreModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            
            var services = context.Services;
            services.AddAbpDbContext<EFCoreDBContext>(o=>o.AddDefaultRepositories(true));
            Configure<AbpDbContextOptions>(o=>o.UseMySQL());

        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            base.OnApplicationInitialization(context);
        }
    }
}