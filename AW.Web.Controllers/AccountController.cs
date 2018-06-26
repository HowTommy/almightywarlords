using System;

namespace AW.Web.Controllers
{
    using AW.Logic.Interfaces;
    using AW.Web.Controllers.Base;
    using AW.Web.Controllers.Models;
    using System.Web.Mvc;
    
    public class AccountController : DefaultControllerBase
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

            var context = CreateContext();

            var user = _userLogic.GetUserByEmailAndPassword(model.Email, model.Password, context);

            if (user == null)
            {
                ViewBag.ErrorMessages = context.Errors;
                return View(model);
            }

            // todo log in user via cookie/session/owin/oauth https://skalp.developpez.com/tutoriels/dotnet/authentification-formulaire-owin-asp-net-mvc-5/

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            throw new NotImplementedException();
        }
    }
}
