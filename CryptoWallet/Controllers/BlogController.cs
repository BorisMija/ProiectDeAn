using System.Web.Mvc;

namespace CryptoWallet.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blog()
        {
            // Poți trimite date către view aici, dacă vrei
            return View();
        }
    }
}