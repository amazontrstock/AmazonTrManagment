using Abp.Authorization;
using AmazonTrManagment.Authorization.Roles;
using AmazonTrManagment.Authorization.Users;

namespace AmazonTrManagment.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
