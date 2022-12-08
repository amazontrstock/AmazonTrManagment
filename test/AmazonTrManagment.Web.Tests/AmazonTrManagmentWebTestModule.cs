using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AmazonTrManagment.EntityFrameworkCore;
using AmazonTrManagment.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AmazonTrManagment.Web.Tests
{
    [DependsOn(
        typeof(AmazonTrManagmentWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class AmazonTrManagmentWebTestModule : AbpModule
    {
        public AmazonTrManagmentWebTestModule(AmazonTrManagmentEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AmazonTrManagmentWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(AmazonTrManagmentWebMvcModule).Assembly);
        }
    }
}