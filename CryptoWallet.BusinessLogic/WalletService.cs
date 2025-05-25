using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using CryptoWallet.Models;
using CryptoWallet.ViewModels;
using System.Data.Entity;
using CryptoWallet.BusinessLogic.DBModel; // presupunând că UserContext este aici

namespace BL.Services
{
    public class WalletService : IWalletService
    {
        private readonly UserContext _context;

        public WalletService(UserContext context)
        {
            _context = context;
        }

        // Returnează datele portofelului pentru un anumit user
        public WalletViewModel GetWalletData(string userId)
        {
            var walletCurrencies = _context.WalletCurrencies
                                           .Where(w => w.UserId == userId)
                                           .ToList();

            var transactions = _context.Transactions
                                       .Where(t => t.UserId == userId)
                                       .ToList();

            return new WalletViewModel
            {
                WalletCurrencies = walletCurrencies,
                Transactions = transactions
            };
        }

        // Adaugă o nouă monedă în portofel
        public async Task AddCurrencyAsync(WalletCurrency currency)
        {
            _context.WalletCurrencies.Add(currency);
            await _context.SaveChangesAsync();
        }

        // Adaugă o tranzacție nouă
        public async Task AddTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        // Adaugă sau actualizează o monedă în portofel (folosită la cumpărare crypto)
        public async Task AddOrUpdateCurrencyAsync(string userId, string symbol, decimal amountToAdd)
        {
            var walletEntry = _context.WalletCurrencies
                .FirstOrDefault(w => w.UserId == userId && w.Symbol == symbol);

            if (walletEntry != null)
            {
                walletEntry.Amount += amountToAdd;
                _context.Entry(walletEntry).State = EntityState.Modified;
            }
            else
            {
                var newEntry = new WalletCurrency
                {
                    UserId = userId,
                    Symbol = symbol,
                    Name = symbol,       // aici poți seta numele complet dacă ai
                    Amount = amountToAdd,
                    Username = userId,   // sau numele de utilizator dacă îl ai
                    CurrencyCode = symbol
                };

                _context.WalletCurrencies.Add(newEntry);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                var errorMessages = e.EntityValidationErrors
                                     .SelectMany(x => x.ValidationErrors)
                                     .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);

                throw new System.Data.Entity.Validation.DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
            }
        }
    }
}