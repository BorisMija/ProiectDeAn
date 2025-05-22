using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Models;
using CryptoWallet.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CryptoWallet.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;

        public RegisterController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _session = bl.GetSessionBL();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reg(UserDataRegister login)
        {
            if (ModelState.IsValid)
            {
                UDataRegister data = new UDataRegister
                {
                    Email = login.Email,
                    Name = login.Name,
                    Password = login.Password,
                  //  LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };

                var userLogin = _session.UserReg(data);

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
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
    }
}