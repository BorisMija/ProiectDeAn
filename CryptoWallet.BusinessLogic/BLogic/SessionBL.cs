using CryptoWallet.BusinessLogic.Core;
using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Domain.Entities.User.UserActionResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.BusinessLogic.BLogic
{
    class SessionBL : UserApi, ISession
     {
          public UserResp GetUserByCookie(string sessionKey)
          {
               return GetUserByCookieAction(sessionKey);
          }
  
     }
}
