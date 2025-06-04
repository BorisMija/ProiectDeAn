using System.Web.Mvc;
using BL.Interfaces;
using CryptoWallet.Domain.Entities.User;

namespace CryptoWallet.Controllers
{
     public class WalletController : Controller
     {
          private readonly IWalletService _walletService;

          public WalletController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _walletService = bl.GetWalletBL();
          }

          [HttpGet]
          public ActionResult Index()
         {
          //     var username = Session["UserName"] as string;
          //     if (string.IsNullOrEmpty(username))
          //          return RedirectToAction("Login", "Auth");

          //     var wallet = _walletService.GetWalletData(username);
               return View();
          }

          //[HttpPost]
          //[ValidateAntiForgeryToken]
          //public ActionResult Index(WalletCurrency model)
          //{
          //     var username = Session["UserName"] as string;
          //     if (string.IsNullOrEmpty(username))
          //          return RedirectToAction("Login", "Auth");

          //     if (ModelState.IsValid)
          //     {
          //          _walletService.AddOrUpdateCurrencyAsync(username, model.Symbol, model.Amount).Wait();
          //          TempData["SuccessMessage"] = "Added successfully.";
          //          return RedirectToAction("Index");
          //     }

          //     TempData["ErrorMessage"] = "Invalid input.";
          //     var wallet = _walletService.GetWalletData(username);
          //     return View(wallet);
          //}
     }
}