using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using BL.Interfaces;
using CryptoWallet.BusinessLogic.DBModel;
using BL.Services;
using Microsoft.AspNet.Identity;

namespace CryptoWallet.Controllers
{
    
    public class BuyCryptoController : Controller
    {
        private readonly IWalletService _walletService;

        // Constructor cu dependency injection
        public BuyCryptoController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        // Constructor fallback (fără DI)
        public BuyCryptoController()
        {
            var userContext = new UserContext();
            _walletService = new WalletService(userContext);
        }

        // GET: BuyCrypto
        public ActionResult Index()
        {
            // Exemplu listă monede (poți lua din DB dacă vrei)
            var availableCurrencies = new List<SelectListItem>
            {
                new SelectListItem { Text = "Bitcoin (BTC)", Value = "BTC" },
                new SelectListItem { Text = "Ethereum (ETH)", Value = "ETH" },
                new SelectListItem { Text = "Litecoin (LTC)", Value = "LTC" }
            };

            ViewBag.Currencies = availableCurrencies;

            return View();
        }

        // POST: BuyCrypto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string symbol, decimal amount)
        {
            var userId = User.Identity.GetUserId();

            if (string.IsNullOrWhiteSpace(symbol) || amount <= 0)
            {
                ModelState.AddModelError("", "Introduceți simbolul și o cantitate validă.");

                // Re-populează dropdown-ul la eroare
                ViewBag.Currencies = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Bitcoin (BTC)", Value = "BTC" },
                    new SelectListItem { Text = "Ethereum (ETH)", Value = "ETH" },
                    new SelectListItem { Text = "Litecoin (LTC)", Value = "LTC" }
                };

                return View();
            }

            await _walletService.AddOrUpdateCurrencyAsync(userId, symbol, amount);

            return RedirectToAction("Index", "Wallet");
        }
    }
}