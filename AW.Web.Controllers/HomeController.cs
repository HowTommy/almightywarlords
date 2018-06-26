namespace AW.Web.Controllers
{
    using System.Web.Mvc;
    using AW.Web.Controllers.Base;

    public class HomeController : DefaultControllerBase
    {
        public ActionResult Index()
        {
            return RedirectToAction("LogIn", "Account");
        }
    }
}
