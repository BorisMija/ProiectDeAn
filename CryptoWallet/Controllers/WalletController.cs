using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using CryptoWallet.Domain.Entities.User;
using BL.Interfaces;
using Microsoft.AspNet.Identity;

namespace CryptoWallet.Controllers
{
   
[Authorize]
     public class WalletController : Controller
     {
          private readonly IWalletService _walletService;
          private string CurrentUserId => User.Identity.GetUserId();

          public WalletController(IWalletService walletService)
          {
               _walletService = walletService ?? throw new ArgumentNullException(nameof(walletService));
          }

          public ActionResult Index()
          {
               var model = _walletService.GetWalletData(CurrentUserId);
               return View(model);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<ActionResult> AddCurrency(WalletCurrency currency)
          {
               if (!ModelState.IsValid)
               {
                    var model = _walletService.GetWalletData(CurrentUserId);
                    return View("Index", model);
               }

               currency.UserId = CurrentUserId;
               await _walletService.AddCurrencyAsync(currency);
               return RedirectToAction("Index");
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<ActionResult> AddTransaction(Transaction transaction)
          {
               if (!ModelState.IsValid)
               {
                    var model = _walletService.GetWalletData(CurrentUserId);
                    return View("Index", model);
               }

               transaction.UserId = CurrentUserId;
               await _walletService.AddTransactionAsync(transaction);
               return RedirectToAction("Index");
          }
     }
}