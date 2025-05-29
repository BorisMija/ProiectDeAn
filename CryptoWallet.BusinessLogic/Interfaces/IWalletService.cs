using CryptoWallet.Domain.Entities.User;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IWalletService
    {
        WalletViewModel GetWalletData(string userId);
        Task AddCurrencyAsync(WalletCurrency currency);
        Task AddTransactionAsync(Transaction transaction);
        Task AddOrUpdateCurrencyAsync(string userId, string symbol, decimal amount);

    }
}