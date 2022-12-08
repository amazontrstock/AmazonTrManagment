using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AmazonTrManagment.Configuration;
using Abp.Hangfire.Configuration;
using Hangfire;
using Hangfire.SqlServer;
using AmazonTrManagment.StockManagment;

namespace AmazonTrManagment.Web.Startup
{
	[DependsOn(typeof(AmazonTrManagmentWebCoreModule))]
	public class AmazonTrManagmentWebMvcModule : AbpModule
	{
		private readonly IWebHostEnvironment _env;
		private readonly IConfigurationRoot _appConfiguration;

		public AmazonTrManagmentWebMvcModule(IWebHostEnvironment env)
		{
			_env = env;
			_appConfiguration = env.GetAppConfiguration();
		}

		public override void PreInitialize()
		{
			Configuration.Navigation.Providers.Add<AmazonTrManagmentNavigationProvider>();
			Configuration.BackgroundJobs.UseHangfire();
			Configuration.BackgroundJobs.IsJobExecutionEnabled = true;
			JobStorage.Current = new SqlServerStorage(_appConfiguration.GetConnectionString("Default"));

		}

		public override void Initialize()
		{
			IocManager.RegisterAssemblyByConvention(typeof(AmazonTrManagmentWebMvcModule).GetAssembly());
		}

		public override void PostInitialize()
		{
			RecurringJob.AddOrUpdate<IStockManagmentService>("TrackStocManagmentsPer1Day", x => x.StartStockManagment(), "0 */1 * * *");
		}


	}
}
