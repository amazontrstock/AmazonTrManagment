using System.Collections.Generic;
using AmazonTrManagment.Roles.Dto;

namespace AmazonTrManagment.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
