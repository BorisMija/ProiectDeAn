using CryptoWallet.BusinessLogic;
using CryptoWallet.Models.Reg;
using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.Domain.Entities.User.Reg;
using CryptoWallet.Domain.User.Reg;
using CryptoWallet.Models.Reg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CryptoWallet.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUser _user;
        public RegisterController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _user = bl.GetUserBL();
        }
        // GET: Register
        public ActionResult Index()
        {
            return View(new UserRegData());
        }

        public ActionResult Reg(UserRegData data)
        {
            var local = new RegDataActionDTO()
            {
                Username = data.Username,
                Password = data.Password,
                Email = data.Email
            };

            UserRegDataResp resp = _user.RegisterUserAction(local);

            return RedirectToAction("Index", "Home");
        }
    }
}