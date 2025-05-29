using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.Domain.Entities.User;
using Microsoft.AspNet.Identity;
using System.Linq;
using BL.Interfaces;
using CryptoWallet.Models.Crypto;

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
          private readonly IWalletService _walletService;

          public SellCryptoController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _walletService = bl.GetWalletBL();

          }


          [HttpGet]
          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(SellCryptoModel sellCryptoModel)
          {
               if (ModelState.IsValid)
               {
                    var data = new SellCrypto
                    {
                         CryptoSymbol = sellCryptoModel.CryptoSymbol,
                         Amount = sellCryptoModel.Amount,
                         Rate = sellCryptoModel.Rate,
                         UserId = 1000
                    };

                    try
                    {
                         var result = _walletService.SellCryptoLogic(data);

                         if (result)
                         {
                              TempData["SuccessMessage"] = "Creat cu succes.";
                         }
                         else
                         {
                              TempData["ErrorMessage"] = "Nu este adaugat. Eroare";
                         }
                    }
                    catch
                    (Exception ex)
                    {
                         // Handle exception (e.g., log it)
                         TempData["ErrorMessage"] = "Nu este adaugat. Eroare";
                         return View(sellCryptoModel);
                    }
                    return RedirectToAction("Index");

               }
               return View(sellCryptoModel);
          }
     }
}
