using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using BL.Interfaces;
using CryptoWallet.BusinessLogic.DBModel;
using Microsoft.AspNet.Identity;

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
     }
}