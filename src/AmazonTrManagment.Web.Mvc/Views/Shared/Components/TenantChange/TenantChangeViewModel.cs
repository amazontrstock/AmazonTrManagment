using Abp.AutoMapper;
using AmazonTrManagment.Sessions.Dto;

namespace AmazonTrManagment.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
