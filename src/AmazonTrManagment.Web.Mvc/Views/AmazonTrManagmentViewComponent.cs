using Abp.AspNetCore.Mvc.ViewComponents;

namespace AmazonTrManagment.Web.Views
{
    public abstract class AmazonTrManagmentViewComponent : AbpViewComponent
    {
        protected AmazonTrManagmentViewComponent()
        {
            LocalizationSourceName = AmazonTrManagmentConsts.LocalizationSourceName;
        }
    }
}
