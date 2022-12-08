using System.Threading.Tasks;
using AmazonTrManagment.Configuration.Dto;

namespace AmazonTrManagment.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
