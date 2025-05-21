using System;
using System.Web.Mvc;
using CryptoWallet.BusinessLogic;
using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Models;

namespace CryptoWallet.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BusinessLogic.BusinessLogic(); // Fixed: Fully qualified the 'BusinessLogic' class to avoid namespace conflict  
            _session = bl.GetSessionBL();
        }

        // GET: Login  
        public ActionResult Index()
        {
            return View();
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

                // Fix: Changed the type from 'UDataRegister' to 'ULoginResult' (or the correct type that contains 'Status' and 'StatusMsg')
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