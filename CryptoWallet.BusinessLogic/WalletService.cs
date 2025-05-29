using System;
using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using CryptoWallet.BusinessLogic.DBModel;
using CryptoWallet. Domain.Entities.User;


namespace BL.Services
{
    public class WalletService : IWalletService
    {
        private readonly UserContext _db;

        public WalletService(UserContext db)
        {
            _db = db;
        }

        public Task AddCurrencyAsync(WalletCurrency currency)
        {
            throw new NotImplementedException();
        }

        public async Task AddOrUpdateCurrencyAsync(string userId, string symbol, decimal amount)
        {
          
            decimal dummyUsdValue = amount * 1000; // Exemplu fix, înlocuiește cu API real

            // Creează tranzacția nouă
            var transaction = new Transaction
            {
                Type = "Buy",
                Currency = symbol,
                Amount = amount,
                ValueInUSD = dummyUsdValue,
                Date = DateTime.UtcNow,
                UserId = userId
            };

            _db.Transactions.Add(transaction);

            // Caută dacă userul are deja această monedă în wallet
            var walletCurrency = _db.WalletCurrencies
                .FirstOrDefault(w => w.UserId == userId && w.Symbol == symbol);

            if (walletCurrency == null)
            {
                walletCurrency = new WalletCurrency
                {
                    UserId = userId,
                    Symbol = symbol,
                    Name = symbol,
                    Amount = 0
                };
                _db.WalletCurrencies.Add(walletCurrency);
            }

            walletCurrency.Amount += amount;

            await _db.SaveChangesAsync();
        }

        public Task AddTransactionAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public WalletViewModel GetWalletData(string userId)
        {
            throw new NotImplementedException();
        }
    }
}