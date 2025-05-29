using BL.Interfaces;
using CryptoWallet.BusinessLogic.Core;
using CryptoWallet.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.BusinessLogic.BLogic
{
     class WalletBL : WalletApi, IWalletService
     {
          public Task AddCurrencyAsync(WalletCurrency currency)
          {
               throw new NotImplementedException();
          }

          public Task AddOrUpdateCurrencyAsync(string userId, string symbol, decimal amount)
          {
               throw new NotImplementedException();
          }

          public Task AddTransactionAsync(Transaction transaction)
          {
               throw new NotImplementedException();
          }

          public WalletViewModel GetWalletData(string userId)
          {
               throw new NotImplementedException();
          }

          public bool SellCryptoLogic(SellCrypto model)
          {
               return SellCrypto(model);
          }
     }
}
