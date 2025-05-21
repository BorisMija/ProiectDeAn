using System;
using System.Web;

namespace CryptoWallet.Domain.Entities.User.UserActionResponse
{
   public class UserCookieResponse
    {
        public HttpCookie cookie { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; } = true;
    }
}
