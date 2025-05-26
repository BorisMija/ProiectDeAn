using System;
using System.Collections.Generic;
using System.Linq;
using CryptoWallet.BusinessLogic.DBModel;  // adaptează namespace dacă e cazul
using CryptoWallet.Models;

namespace CryptoWallet.BusinessLogic.Core
{
    public class WalletApi
    {
        public bool BuyCrypto(string userId, string currencySymbol, decimal amount, decimal valueInUSD)
        {
            using (var db = new UserContext())
            {
                var transaction = new Transaction
                {
                    Type = "Buy",
                    Currency = currencySymbol,
                    Amount = amount,
                    ValueInUSD = valueInUSD,
                    Date = DateTime.Now,
                    UserId = userId
                };
                db.Transactions.Add(transaction);

                var wallet = db.WalletCurrencies
                    .FirstOrDefault(w => w.UserId == userId && w.Symbol == currencySymbol);

                if (wallet == null)
                {
                    wallet = new WalletCurrency
                    {
                        UserId = userId,
                        Symbol = currencySymbol,
                        Name = currencySymbol,
                        Amount = 0
                    };
                    db.WalletCurrencies.Add(wallet);
                }

                wallet.Amount += amount;

                db.SaveChanges();

                return true;
            }
        }

        public decimal GetWalletBalance(string userId, string currencySymbol)
        {
            using (var db = new UserContext())
            {
                var wallet = db.WalletCurrencies
                    .FirstOrDefault(w => w.UserId == userId && w.Symbol == currencySymbol);

                return wallet?.Amount ?? 0;
            }
        }

        public List<Transaction> GetTransactionsHistory(string userId)
        {
            using (var db = new UserContext())
            {
                return db.Transactions
                    .Where(t => t.UserId == userId)
                    .OrderByDescending(t => t.Date)
                    .ToList();
            }
        }
    }
}