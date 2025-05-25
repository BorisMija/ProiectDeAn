using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using CryptoWallet.Models;
using CryptoWallet.ViewModels;
using BL.Interfaces;
using BL.Services;
using CryptoWallet.BusinessLogic.DBModel;
using Microsoft.AspNet.Identity; // pentru User.Identity.GetUserId()

namespace CryptoWallet.Controllers
{
   
    public class WalletController : Controller
    {
        private readonly IWalletService _walletService;

        // Constructor principal cu dependency injection
        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        // Constructor fallback (pentru când DI nu e configurat)
        public WalletController()
        {
            var userContext = new UserContext(); // adaptează la contextul tău real
            _walletService = new WalletService(userContext);
        }

        // GET: Wallet
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var model = _walletService.GetWalletData(userId);
            return View(model);
        }

        // POST: Wallet/AddCurrency
        [HttpPost]
        public async Task<ActionResult> AddCurrency(WalletCurrency currency)
        {
            if (!ModelState.IsValid)
            {
                var model = _walletService.GetWalletData(User.Identity.GetUserId());
                return View("Index", model);
            }

            currency.UserId = User.Identity.GetUserId(); // asigură-te că e legat de user
            await _walletService.AddCurrencyAsync(currency);
            return RedirectToAction("Index");
        }

        // POST: Wallet/AddTransaction
        [HttpPost]
        public async Task<ActionResult> AddTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                var model = _walletService.GetWalletData(User.Identity.GetUserId());
                return View("Index", model);
            }

            transaction.UserId = User.Identity.GetUserId();
            await _walletService.AddTransactionAsync(transaction);
            return RedirectToAction("Index");
        }
    }
}