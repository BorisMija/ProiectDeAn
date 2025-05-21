using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using CryptoWallet.Domain.Entities.User.UserActionResponse;
using CryptoWallet.Domain.Enums;
using CryptoWallet.BusinessLogic.Interfaces;
namespace CryptoWallet.LogicHelper.Attributes
{
    public class IsAdminAttribute: ActionFilterAttribute
    {
        private readonly ISession _session;

        public IsAdminAttribute()
        {
            
            var bl = new CryptoWallet.BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionKey = HttpContext.Current.Request.Cookies["X-KEY"];

            if (sessionKey != null)
            {
                UserResp profile = _session.GetUserByCookie(sessionKey.Value);

                if (profile != null && profile.Role != URole.Admin)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new { controller = "Home", action = "Index" }));
                }
            }
        }
    }
}
