using CryptoWallet.Domain.Entities.User;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CryptoWallet.Controllers
{
    public class RdminController : Controller
    {
        private const int ModeratorLevel = 238;

        public ActionResult Index()
        {
            if (!UserIsModeratorOrAbove())
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            // Logica ta pentru afișarea datelor în view
            var users = GetUsers();

            return View(users);
        }

        private bool UserIsModeratorOrAbove()
        {
            var levelObj = Session["UserLevel"];
            if (levelObj == null)
                return false;

            if (int.TryParse(levelObj.ToString(), out int level))
            {
                return level >= ModeratorLevel;
            }
            return false;
        }

        private List<UserData> GetUsers()
        {
            // Exemplu de listă demo, înlocuiește cu date reale
            return new List<UserData>
            {
                new UserData { Username = "ionut", Email = "ionut@example.com", Level = 1200, IsBlocked = false },
                new UserData { Username = "ana", Email = "ana@example.com", Level = 237, IsBlocked = false },
                new UserData { Username = "mihai", Email = "mihai@example.com", Level = 0, IsBlocked = true }
            };
        }
    }
}