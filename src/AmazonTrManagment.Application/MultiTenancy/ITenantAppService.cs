using Abp.Application.Services;
using AmazonTrManagment.MultiTenancy.Dto;

namespace AmazonTrManagment.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

