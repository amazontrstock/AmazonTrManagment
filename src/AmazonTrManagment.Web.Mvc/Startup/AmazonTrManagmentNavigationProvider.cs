using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using AmazonTrManagment.Authorization;

namespace AmazonTrManagment.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class AmazonTrManagmentNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
					new MenuItemDefinition(
						PageNames.Products,
						L("Products"),
						url: "Products",
						icon: "fas fa-home",
						requiresAuthentication: true
					)
				);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AmazonTrManagmentConsts.LocalizationSourceName);
        }
    }
}