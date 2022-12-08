using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AmazonTrManagment.Configuration.Dto;

namespace AmazonTrManagment.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AmazonTrManagmentAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
