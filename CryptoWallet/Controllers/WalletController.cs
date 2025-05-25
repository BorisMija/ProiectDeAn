using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using CryptoWallet.Models;
using CryptoWallet.ViewModels;
using BL.Interfaces;          // interfața IWalletService
using BL.Services;            // implementarea WalletService

using CryptoWallet.BusinessLogic.DBModel;      // UserContext (sau cum îl ai definit)

namespace CryptoWallet.Controllers
{
    public class WalletController : Controller
    {
        private readonly IWalletService _walletService;

        // Constructor cu DI (pentru când vei configura DI corect)
        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        // Constructor fără parametri - fallback pentru a evita eroarea
        public WalletController()
        {
            var userContext = new UserContext();       // adaptează namespace-ul/corect
            _walletService = new WalletService(userContext);
        }

        // GET: Wallet
        public ActionResult Index()
        {
            var model = _walletService.GetWalletData();
            return View(model);
        }

        // POST: Wallet/AddCurrency
        [HttpPost]
        public async Task<ActionResult> AddCurrency(WalletCurrency currency)
        {
            if (!ModelState.IsValid)
            {
                var model = _walletService.GetWalletData();
                return View("Index", model);
            }

            await _walletService.AddCurrencyAsync(currency);
            return RedirectToAction("Index");
        }

        // POST: Wallet/AddTransaction
        [HttpPost]
        public async Task<ActionResult> AddTransaction(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                var model = _walletService.GetWalletData();
                return View("Index", model);
            }

            await _walletService.AddTransactionAsync(transaction);
            return RedirectToAction("Index");
        }
    }
}