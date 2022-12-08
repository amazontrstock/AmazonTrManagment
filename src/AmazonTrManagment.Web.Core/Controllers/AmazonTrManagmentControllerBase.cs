using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AmazonTrManagment.Controllers
{
    public abstract class AmazonTrManagmentControllerBase: AbpController
    {
        protected AmazonTrManagmentControllerBase()
        {
            LocalizationSourceName = AmazonTrManagmentConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
