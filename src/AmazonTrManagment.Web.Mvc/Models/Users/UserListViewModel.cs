using System.Collections.Generic;
using AmazonTrManagment.Roles.Dto;

namespace AmazonTrManagment.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
