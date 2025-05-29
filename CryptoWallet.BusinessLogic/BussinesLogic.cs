using BL.Interfaces;
using CryptoWallet.BusinessLogic.BLogic;
using CryptoWallet.BusinessLogic.Core;
using CryptoWallet.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.BusinessLogic
{
    public class BussinesLogic
    {
        public IUser GetUserBL()
        {
            return new UserBL();
        }

          public IWalletService GetWalletBL()
          {
               return new WalletBL();
          }
    }
}