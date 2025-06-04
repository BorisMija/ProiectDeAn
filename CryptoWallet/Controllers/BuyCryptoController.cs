using System.Web.Mvc;
using BL.Interfaces;
using CryptoWallet.Domain.Entities.User;

namespace CryptoWallet.Controllers
{
     public class BuyCryptoController : Controller
     {
          private readonly IWalletService _walletService;

          public BuyCryptoController()
          {
               var bl = new BusinessLogic.BussinesLogic();
               _walletService = bl.GetWalletBL();
          }

          [HttpGet]
          public ActionResult Index()
          {
               var offers = _walletService.GetSellCryptoLogic();
               return View(offers);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Buy(int id)
          {
               var userName = Session["UserName"] as string;
               if (string.IsNullOrEmpty(userName))
               {
                    TempData["ErrorMessage"] = "Please log in first.";
                    return RedirectToAction("Index");
               }

               var success = _walletService.BuyCryptoLogic(id, userName);
               TempData[success ? "SuccessMessage" : "ErrorMessage"] = success
                   ? "Crypto bought successfully."
                   : "Offer not found or already sold.";

               return RedirectToAction("Index");
          }

     }
}
