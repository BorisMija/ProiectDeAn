using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Domain.Entities.User.Reg;
using CryptoWallet.Domain.User.Auth;
using CryptoWallet.Domain.User.Reg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CryptoWallet.BusinessLogic.Interfaces
{
    public interface IUser
    {
        string AuthenticateUser(UserAuthAction auth);
        UDbTable GetUserByUsername(string username);
          object GetWalletByUserId(string userId);
          UserRegDataResp RegisterUserAction(RegDataActionDTO local);

          Task UpdateWalletAsync(string userId, WalletViewModel wallet);
          Task LogTransactionAsync(Transaction transaction);
     


          //ActionResult Logout();


     }
}