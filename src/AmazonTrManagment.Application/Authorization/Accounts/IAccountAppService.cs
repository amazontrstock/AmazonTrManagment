using System.Threading.Tasks;
using Abp.Application.Services;
using AmazonTrManagment.Authorization.Accounts.Dto;

namespace AmazonTrManagment.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
