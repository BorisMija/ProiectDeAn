using CryptoWallet.Models;
using CryptoWallet.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CryptoWallet.Controllers
{
   
    public class WalletController : Controller
    {
        public ActionResult Index()
        {
            var model = new WalletViewModel
            {
                WalletCurrencies = new List<WalletCurrency>
                {
                    new WalletCurrency { Id = 1, Name = "Bitcoin", Symbol = "BTC", Amount = 0.543m },
                    new WalletCurrency { Id = 2, Name = "Ethereum", Symbol = "ETH", Amount = 2.1m }
                },
                Transactions = new List<Transaction>
                {
                    new Transaction { Id = 1, Date = DateTime.Now.AddDays(-2), Type = "Buy", Currency = "BTC", Amount = 0.2m, ValueInUSD = 14000 },
                    new Transaction { Id = 2, Date = DateTime.Now.AddDays(-1), Type = "Sell", Currency = "ETH", Amount = 1.0m, ValueInUSD = 2200 }
                }
            };

            return View(model);
        }
    }
}