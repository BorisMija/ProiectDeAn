using CryptoWallet.BusinessLogic.Core;
using CryptoWallet.Domain.Entities.User.Reg;
using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Domain.User.Reg;
using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.Domain.User.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CryptoWallet.BusinessLogic.BLogic
{
    public class UserBL : UserApi, IUser
    {
        public string AuthenticateUser(UserAuthAction auth)
        {
            return AuthenticateUserAction(auth);
        }
        public UDbTable GetUserByUsername(string username)
        {
            return GetUserByUsernameAction(username);
        }
        //public int GetUserIdBySessionKey(string sessionKey)
        //{
        //     return GetUserIdBySessionKeyAction(sessionKey);
        //}

        //public bool IsSessionValid(string key)
        //{
        //     return IsSessionValidAction(key);
        //}
        public UserRegDataResp RegisterUserAction(RegDataActionDTO local)
        {
            return SetRegisterUserAction(local);
        }

          //public ActionResult Logout()
          // {
          //      return LogOutUser();
          // }
          public object GetWalletByUserId(string userId)
          {
               // Explicitly implement the interface method to match the return type
               return base.GetWalletByUserId(userId);
          }

          public Task UpdateWalletAsync(string userId, WalletViewModel wallet)
          {
               return base.UpdateWalletAsync(userId, wallet);
          }

          public Task LogTransactionAsync(Transaction transaction)
          {
               return base.LogTransactionAsync(transaction);
          }

     }
}