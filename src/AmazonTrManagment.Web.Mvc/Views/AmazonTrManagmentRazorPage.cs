using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AmazonTrManagment.Web.Views
{
    public abstract class AmazonTrManagmentRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AmazonTrManagmentRazorPage()
        {
            LocalizationSourceName = AmazonTrManagmentConsts.LocalizationSourceName;
        }
    }
}
