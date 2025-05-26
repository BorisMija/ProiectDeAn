using System.Collections.Generic;
using System.Linq;
using CryptoWallet.BusinessLogic.DBModel;
using CryptoWallet.Domain.Entities.User;

namespace CryptoWallet.BusinessLogic.Core
{
    public class AdminApi
    {
        /// <summary>
        /// Returnează toți utilizatorii din baza de date.
        /// </summary>
        public List<UDbTable> GetAllUsers()
        {
            using (var db = new UserContext())
            {
                return db.Users.ToList();
            }
        }

        /// <summary>
        /// Returnează un utilizator după username (admin sau user).
        /// </summary>
        public UDbTable GetUserByUsername(string username)
        {
            using (var db = new UserContext())
            {
                return db.Users.FirstOrDefault(u => u.Username == username);
            }
        }

        /// <summary>
        /// Șterge un utilizator după username.
        /// </summary>
        public bool DeactivateUser(string username)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                    return false;

                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
        }
    }
}