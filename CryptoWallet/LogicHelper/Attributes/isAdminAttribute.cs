using CryptoWallet.Domain.Entities.User.UserActionResponse;
using CryptoWallet.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CryptoWallet.BusinessLogic.Interfaces;
using System.Web.Routing;

namespace CryptoWallet.LogicHelper.Attributes
{
     public class isAdminAttribute : ActionFilterAttribute
     {
          private readonly BusinessLogic.Interfaces.ISession _session;
          public isAdminAttribute()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _session = bl.GetSessionBL();
          }
          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               var sessionKey = System.Web.HttpContext.Current.Request.Cookies["X-KEY"];

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
