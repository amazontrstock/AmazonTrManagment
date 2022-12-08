using Abp.Application.Services.Dto;

namespace AmazonTrManagment.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

