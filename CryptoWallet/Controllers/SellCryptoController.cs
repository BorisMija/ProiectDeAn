using System;
using System.Web.Mvc;
using CryptoWallet.Domain.Entities.User;
using BL.Interfaces;
using CryptoWallet.Models.Crypto;
using CryptoWallet.Models.Reg;

namespace CryptoWallet.Controllers
{
public class SellCryptoController : Controller
     {
         

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
                         UserName = Session["UserName"] as string
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
                         TempData["ErrorMessage"] = "Nu este adaugat. Eroare";
                         return View(sellCryptoModel);
                    }
                    return RedirectToAction("Index");

               }
               return View(sellCryptoModel);
          }
     }

}
