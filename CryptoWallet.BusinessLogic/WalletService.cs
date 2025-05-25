using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using CryptoWallet.Models;
using CryptoWallet.ViewModels;
using System.Data.Entity;
using CryptoWallet.BusinessLogic.DBModel; // presupunând că ApplicationDbContext e aici

namespace BL.Services
{
    public class WalletService : IWalletService
    {
        private readonly UserContext _context;

        public WalletService(UserContext context)
        {
            _context = context;
        }

        public WalletViewModel GetWalletData()
        {
            return new WalletViewModel
            {
                WalletCurrencies = _context.WalletCurrencies.ToList(),
                Transactions = _context.Transactions.ToList()
            };
        }

        public async Task AddCurrencyAsync(WalletCurrency currency)
        {
            _context.WalletCurrencies.Add(currency);
            await _context.SaveChangesAsync();
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
    }
}