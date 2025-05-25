using CryptoWallet.Models;
using CryptoWallet.ViewModels;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IWalletService
    {
        WalletViewModel GetWalletData();
        Task AddCurrencyAsync(WalletCurrency currency);
        Task AddTransactionAsync(Transaction transaction);
    }
}