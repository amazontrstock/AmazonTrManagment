using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AmazonTrManagment.Authorization;

namespace AmazonTrManagment
{
    [DependsOn(
        typeof(AmazonTrManagmentCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AmazonTrManagmentApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AmazonTrManagmentAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AmazonTrManagmentApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
