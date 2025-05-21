using CryptoWallet.LogicHelper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CryptoWallet.Controllers
{
    public class AdminController : BaseController
    {
  
            // GET: Admin
            [IsAdmin]
            public ActionResult Index()
            {
                SessionStatus();
                if (Session["LoginStatus"] == null || Session["LoginStatus"].ToString() != "login")
                {
                    return RedirectToAction("Login", "Account");
                }

                ViewBag.HideFooter = true;
                return View();
            }
        }
    
}