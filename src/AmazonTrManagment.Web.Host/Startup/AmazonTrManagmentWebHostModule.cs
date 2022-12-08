using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AmazonTrManagment.Configuration;

namespace AmazonTrManagment.Web.Host.Startup
{
    [DependsOn(
       typeof(AmazonTrManagmentWebCoreModule))]
    public class AmazonTrManagmentWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AmazonTrManagmentWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AmazonTrManagmentWebHostModule).GetAssembly());
        }
    }
}
