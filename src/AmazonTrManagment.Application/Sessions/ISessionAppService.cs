using System.Threading.Tasks;
using Abp.Application.Services;
using AmazonTrManagment.Sessions.Dto;

namespace AmazonTrManagment.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
