using CryptoWallet.Domain.Entities.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IWalletService
    {
        WalletViewModel GetWalletData(string userId);
        Task AddCurrencyAsync(WalletCurrency currency);
        Task AddTransactionAsync(Transaction transaction);
        Task AddOrUpdateCurrencyAsync(string userId, string symbol, decimal amount);
         bool SellCryptoLogic(SellCrypto sellCrypto);
        
          List<SellCrypto> GetSellCryptoLogic();
          bool BuyCryptoLogic(int offerId, string userName);

          //WalletViewModel GetWalletData(string userName);
          //Task AddOrUpdateCurrencyAsync(string userName, string symbol, decimal amount);
     }
}