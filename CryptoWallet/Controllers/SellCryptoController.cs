using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.Domain.Entities.User;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace CryptoWallet.Controllers
{
public class SellCryptoController : Controller
     {
          //private readonly BusinessLogic.Interfaces.IUser _userService;


          //public SellCryptoController(BusinessLogic.Interfaces.IUser userService)
          //{
          //     _userService = userService ?? throw new ArgumentNullException(nameof(userService));
          //}

          //// GET: SellCrypto  
          //public ActionResult Index()
          //{
          //     var userId = User.Identity.GetUserId();
          //     var wallet = _userService.GetWalletByUserId(userId);
          //     return View(wallet);
          //}

          //// POST: SellCrypto/Sell  
          //[HttpPost]
          //[ValidateAntiForgeryToken]
          //public async Task<ActionResult> Sell(string cryptoSymbol, decimal amount, decimal rate)
          //{
          //     if (string.IsNullOrEmpty(cryptoSymbol) || amount <= 0 || rate <= 0)
          //     {
          //          ModelState.AddModelError("", "Invalid input data.");
          //          return RedirectToAction("Index");
          //     }

          //     var userId = User.Identity.GetUserId();
          //     var wallet = _userService.GetWalletByUserId(userId) as WalletViewModel;

          //     if (wallet == null)
          //     {
          //          ModelState.AddModelError("", "Wallet not found.");
          //          return RedirectToAction("Index");
          //     }

          //     // Fix for CS1061: Replace the incorrect property access with the correct one based on the WalletViewModel definition.
          //     var currency = wallet.WalletCurrencies?.FirstOrDefault(c => c.Symbol == cryptoSymbol);
          //     if (currency == null)
          //     {
          //          ModelState.AddModelError("", "Currency not found in wallet.");
          //          return RedirectToAction("Index");
          //     }

          //     // Update wallet and log transaction  
          //     currency.Amount -= amount;
          //     await _userService.UpdateWalletAsync(userId, wallet);

          //     var transaction = new Transaction
          //     {
          //          Type = "Sell",
          //          Currency = cryptoSymbol,
          //          Amount = amount,
          //          ValueInUSD = amount * rate,
          //          Date = DateTime.Now,
          //          UserId = userId
          //     };
          //     await _userService.LogTransactionAsync(transaction);

          //     TempData["Success"] = "Crypto sold successfully!";
          //     return RedirectToAction("Index");


          //}

          public ActionResult Index()
          {
               return View();
          }
     }
}
