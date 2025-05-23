using System.Web.Mvc;

namespace CryptoWallet.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var token = Session["UserToken"] as string;

            if (string.IsNullOrEmpty(token) && Request.Cookies["UserToken"] != null)
            {
                token = Request.Cookies["UserToken"].Value;
            }

            return View();
        }
    }
}