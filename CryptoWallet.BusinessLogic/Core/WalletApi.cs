using System;
using System.Collections.Generic;
using System.Linq;
using CryptoWallet.BusinessLogic.DBModel;  // adaptează namespace dacă e cazul
using CryptoWallet.Domain.Entities.User;

namespace CryptoWallet.BusinessLogic.Core
{
     public class WalletApi
     {
          public bool BuyCrypto(string userName, string currencySymbol, decimal amount, decimal valueInUSD)
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
                         UserName = userName
                    };
                    db.Transactions.Add(transaction);

                    var wallet = db.WalletCurrencies
                        .FirstOrDefault(w => w.UserName == userName && w.Symbol == currencySymbol);

                    if (wallet == null)
                    {
                         wallet = new WalletCurrency
                         {
                              UserName = userName,
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

          public bool SellCrypto(SellCrypto model)
          {
               using (var db = new UserContext())
               {
                    var transaction = new SellCrypto
                    {
                         CryptoSymbol = model.CryptoSymbol,
                         Amount = model.Amount,
                         Rate = model.Rate,
                         UserName = model.UserName,
                         isAvailable = true,
                         Date = DateTime.Now
                    };

                    db.SellCryptos.Add(transaction);
                    db.SaveChanges();
                    return true;
               }

               return false;
          }

          public bool BuyCryptoOffer(int offerId, string userName)
          {
               using (var db = new UserContext())
               {
                    // 1. Find the available offer
                    var offer = db.SellCryptos.FirstOrDefault(o => o.Id == offerId && o.isAvailable);
                    if (offer == null)
                         return false;

                    // 2. Mark offer as sold
                    offer.isAvailable = false;

                    // 3. Update or create wallet
                    var wallet = db.WalletCurrencies.FirstOrDefault(w => w.UserName == userName && w.Symbol == offer.CryptoSymbol);
                    if (wallet == null)
                    {
                         wallet = new WalletCurrency
                         {
                              UserName = userName,
                              Symbol = offer.CryptoSymbol,
                              Name = offer.CryptoSymbol,
                              Amount = 0
                         };
                         db.WalletCurrencies.Add(wallet);
                    }

                    wallet.Amount += offer.Amount;

                    // 4. Log the transaction
                    var transaction = new Transaction
                    {
                         Type = "Buy",
                         Currency = offer.CryptoSymbol,
                         Amount = offer.Amount,
                         ValueInUSD = offer.Amount * offer.Rate,
                         Date = DateTime.Now,
                         UserName = userName // ✅ if this is your identifier
                    };
                    db.Transactions.Add(transaction);

                    // 5. Save changes
                    db.SaveChanges();
                    return true;
               }
          }



          public List<SellCrypto> GetCryptosForSale()
          {
               using (var db = new UserContext())
               {
                    return db.SellCryptos
                         .Where(c => c.isAvailable)
                         .OrderByDescending(c => c.Date)
                         .ToList();
               }
          }
          public decimal GetWalletBalance(string userName, string currencySymbol)
          {
               using (var db = new UserContext())
               {
                    var wallet = db.WalletCurrencies
                        .FirstOrDefault(w => w.UserName == userName && w.Symbol == currencySymbol);

                    return wallet?.Amount ?? 0;
               }
          }

          public List<Transaction> GetTransactionsHistory(string UserName)
          {
               using (var db = new UserContext())
               {
                    return db.Transactions
                        .Where(t => t.UserName == UserName)
                        .OrderByDescending(t => t.Date)
                        .ToList();
               }
          }
          //public WalletCur GetWalletData(string userId)
          //{
          //     using (var db = new UserContext())
          //     {
          //          var currencies = db.WalletCurrencies
          //              .Where(w => w.UserName == userId)
          //              .ToList();

          //          return new WalletViewModel
          //          {
          //               Currencies = currencies,
          //               AddModel = new WalletCurrency()
          //          };
          //     }

          //}
     }
}
