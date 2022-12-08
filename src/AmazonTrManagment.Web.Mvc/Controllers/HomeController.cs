using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AmazonTrManagment.Controllers;

namespace AmazonTrManagment.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AmazonTrManagmentControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
