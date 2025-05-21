using CryptoWallet.Domain.Entities.User.UserActionResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CryptoWallet.LogicHelper;
using CryptoWallet.BusinessLogic.Interfaces;

namespace CryptoWallet.Controllers
{
    public class BaseController : Controller
    {
        private readonly ISession _session;
        public BaseController()
        {

            var bl = new CryptoWallet.BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();

        }

        //session status check
        public void SessionStatus()
        {
            var sessionKey = Request.Cookies["X-KEY"];
            if (sessionKey != null)
            {
                UserResp profile = _session.GetUserByCookie(sessionKey.Value);

                if (User != null && profile.Status)
                {
                    System.Web.HttpContext.Current.SetUserProfile(profile);
                    System.Web.HttpContext.Current.Session["LoginStatus"] = "login";
                    System.Web.HttpContext.Current.Session["UserFirstName"] = profile.Name;
                    System.Web.HttpContext.Current.Session["UserId"] = profile.UserId;

                }
                else
                {
                    System.Web.HttpContext.Current.Session.Clear();
                    if (ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("X-KEY"))
                    {
                        var cookie = ControllerContext.HttpContext.Request.Cookies["X-KEY"];
                        if (cookie != null)
                        {
                            cookie.Expires = DateTime.Now.AddDays(-1);
                            ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                        }
                    }

                    System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
                }
            }
            else
            {
                System.Web.HttpContext.Current.Session["LoginStatus"] = "logout";
            }
        }
    }
}