using System;
using System.Web.Mvc;
using CryptoWallet.BusinessLogic;
using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Models;
using CryptoWallet.Models.Login;

namespace CryptoWallet.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _session = bl.GetSessionBL();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View(new UserLogin());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    NameOrEmail = login.NameOrEmail,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };

                var userLogin = _session.UserLogin(data);

                if (userLogin.Status)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                }
            }

            return View();
        }
    }
}