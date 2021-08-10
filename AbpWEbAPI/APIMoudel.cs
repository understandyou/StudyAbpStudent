using System.IO;
using EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.EventBus;
using Volo.Abp.Identity.Web;
using Volo.Abp.Modularity;

namespace AbpWEbAPI
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule)
    ,typeof(EFCoreModule)
    , typeof(AbpAutofacModule)
    )]
    public class APIMoudel:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo(){Title = "这是一个demo",Version = "v1"});
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取主程序集文件夹
                var psth = Path.Combine(basePath, "abpWebAPI.xml");//组合注释路径
                //如果在配置生成xml注释是报错，可以在生成里面添加忽略错误代码
                c.IncludeXmlComments(psth);//添加注释描述
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var env = context.GetEnvironment();
            var app = context.GetApplicationBuilder();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}