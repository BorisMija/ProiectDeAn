using CryptoWallet.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.Models.Auth;
using System.Web.Configuration;
using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Domain.User.Auth;

namespace CryptoWallet.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUser _user;
        public AuthController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _user = bl.GetUserBL();
        }
        // GET: Auth
        public ActionResult Index()
        {
            return View(new UserAuthData());
        }
        public ActionResult Logout()
        {
            Session.Clear();

            if (Request.Cookies["UserToken"] != null)
            {
                var cookie = new HttpCookie("UserToken");
                cookie.Expires = DateTime.Now.AddDays(-1); // Expiră cookie-ul
                Response.Cookies.Add(cookie);
            }

            return RedirectToAction("Index", "Auth");
        }
        [HttpPost]
        public ActionResult Auth(UserAuthData data)
        {
            var auth = new UserAuthAction()
            {
                LoginTime = DateTime.Now,
                Password = data.Password,
                Username = data.Username
            };

            string token = _user.AuthenticateUser(auth);
            if (!string.IsNullOrEmpty(token))
            {
                var user = _user.GetUserByUsername(auth.Username);

                Session["Username"] = user.Username;
                Session["UserLevel"] = (int)user.Level;

                Session["UserToken"] = token;

                return RedirectToAction("Index", "Home");
            }


            ModelState.AddModelError("", "Autentificare eșuată. Verifică datele.");
            return View("Index", data);
        }
    }
}