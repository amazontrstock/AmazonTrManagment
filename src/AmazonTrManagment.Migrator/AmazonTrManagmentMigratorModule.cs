using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AmazonTrManagment.Configuration;
using AmazonTrManagment.EntityFrameworkCore;
using AmazonTrManagment.Migrator.DependencyInjection;

namespace AmazonTrManagment.Migrator
{
    [DependsOn(typeof(AmazonTrManagmentEntityFrameworkModule))]
    public class AmazonTrManagmentMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AmazonTrManagmentMigratorModule(AmazonTrManagmentEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(AmazonTrManagmentMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AmazonTrManagmentConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AmazonTrManagmentMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
