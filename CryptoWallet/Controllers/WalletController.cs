using CryptoWallet.Models;
using CryptoWallet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CryptoWallet.Controllers
{
    [System.Web.Mvc.Authorize(Roles = "User,Moderator,Admin")]
    public class WalletController : Controller
    {
        public IActionResult Index()
        {
            var model = new WalletViewModel
            {
                WalletCurrencies = new List<WalletCurrency>
                {
                    new WalletCurrency { Name = "Bitcoin", Symbol = "BTC", Amount = 0.543m },
                    new WalletCurrency { Name = "Ethereum", Symbol = "ETH", Amount = 2.1m }
                },
                Transactions = new List<Transaction>
                {
                    new Transaction { Date = DateTime.Now.AddDays(-2), Type = "Buy", Currency = "BTC", Amount = 0.2m, ValueInUSD = 14000 },
                    new Transaction { Date = DateTime.Now.AddDays(-1), Type = "Sell", Currency = "ETH", Amount = 1.0m, ValueInUSD = 2200 }
                }
            };

            return (IActionResult)View(model); // Fără conversie inutilă
        }
    }
}