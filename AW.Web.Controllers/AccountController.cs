namespace AW.Web.Controllers
{
    using AW.Logic.Interfaces;
    using AW.Resources;
    using AW.Web.Controllers.Base;
    using AW.Web.Controllers.Models;
    using System.Web.Mvc;
    
    public class AccountController : BaseController
    {
        private readonly IUserLogic _userLogic;

        public AccountController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            var model = new AccountLogInModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(AccountLogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userLogic.GetUserByEmailAndPassword(model.Email, model.Password);

            if (user == null)
            {
                ViewBag.Error = Resource.Error_UnknownUser;
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
