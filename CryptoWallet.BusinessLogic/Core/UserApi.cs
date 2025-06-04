using System;
using System.Web;
using System.Data.Entity;
using System.Linq;
using CryptoWallet.BusinessLogic.DBModel;
using CryptoWallet.Domain.Entities.Session;
using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Domain.Entities.User.UserActionResponse;
using CryptoWallet.Domain.Enums;
using Microsoft.AspNetCore.Http;
using CryptoWallet.Domain.Entities.User.Reg;
using CryptoWallet.Domain.User.Reg;
using CryptoWallet.Domain.User.Auth;
using System.Threading.Tasks;
using CryptoWallet.Helpers.Session;




namespace CryptoWallet.BusinessLogic.Core
{
    public class UserApi
    {
        public string AuthenticateUserAction(UserAuthAction auth)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u =>
                    u.Username == auth.Username &&
                    u.Password == auth.Password
                );

                if (user != null)
                {
                    user.LastLogin = DateTime.Now;
                    db.SaveChanges();

                    return Guid.NewGuid().ToString();
                }
            }

            return null;
        }
        public UDbTable GetUserByUsernameAction(string username)
        {
            using (var db = new UserContext())
            {
                return db.Users.FirstOrDefault(u => u.Username == username);
            }
        }
        public UserRegDataResp SetRegisterUserAction(RegDataActionDTO local)
        {

            UDbTable user;

            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Username == local.Username);
            }

            if (user != null)
            {
                return new UserRegDataResp()
                {
                    Status = false,
                    Error = "This Username exists"
                };
            }

            var u_data = new UDbTable()
            {
                Username = local.Username,
                Password = local.Password,
                Email = local.Email,
                LastLogin = DateTime.Now,
                Level = URole.User,
            };

            using (var db = new UserContext())
            {
                db.Users.Add(u_data);
                db.SaveChanges();
            }




            return new UserRegDataResp() { Status = true };
        }
        public WalletViewModel GetWalletByUserId(string userId)
          {
               using (var db = new UserContext())
               {
                    var walletCurrencies = db.WalletCurrencies.Where(c => c.UserId == userId).ToList();
                    var transactions = db.Transactions.Where(t => t.UserId == userId).ToList();

                    return new WalletViewModel
                    {
                         WalletCurrencies = walletCurrencies,
                         Transactions = transactions
                    };
               }
          }
          public async Task UpdateWalletAsync(string userId, WalletViewModel wallet)
          {
               using (var db = new UserContext())
               {
                    foreach (var currency in wallet.WalletCurrencies)
                    {
                         var existingCurrency = db.WalletCurrencies.FirstOrDefault(c => c.Id == currency.Id);
                         if (existingCurrency != null)
                         {
                              existingCurrency.Amount = currency.Amount;
                         }
                    }
                    await db.SaveChangesAsync();
               }
          }

          public async Task LogTransactionAsync(Transaction transaction)
          {
               using (var db = new UserContext())
               {
                    db.Transactions.Add(transaction);
                    await db.SaveChangesAsync();
               }
          }
     
       public UserCookieResponse GenerateCookieByUserAction(int userId)
          {
               var cookieString = new System.Web.HttpCookie("X-KEY")
               {
                    Value = CookieGenerator.Create(userId + System.Web.HttpContext.Current.Request.UserHostAddress)
               };


               SessionDbTable sessionDb;

               using (var db = new SessionContext())
               {
                    sessionDb = db.Sessions.FirstOrDefault(u => u.UserId == userId);
               }

               var dateTime = DateTime.Now;

               //if session exist
               if (sessionDb != null)
               {
                    sessionDb.Cookie = cookieString.Value;
                    sessionDb.ValidTime = dateTime.AddHours(3);

                    using (var db = new SessionContext())
                    {
                         db.Entry(sessionDb).State = EntityState.Modified;
                         db.SaveChanges();
                    }
               }

            
               else
               {
                    sessionDb = new SessionDbTable()
                    {
                         UserId = userId,
                         Cookie = cookieString.Value,
                         ValidTime = dateTime.AddHours(3)
                    };

                    using (var db = new SessionContext())
                    {
                         db.Sessions.Add(sessionDb);
                         db.SaveChanges();
                    }
               }

               return new UserCookieResponse()
               {
                    UserId = userId,
                    cookie = cookieString,
                    ExpirationDate = dateTime
               };
          }

          public UserResp GetUserByCookieAction(string cookieKey)
          {
               SessionDbTable session;
               UDbTable user;

               using (var db = new SessionContext())
               {
                    session = db.Sessions.FirstOrDefault(s => s.Cookie.Contains(cookieKey));
               }

               if (session != null)
               {
                    using (var db = new UserContext())
                    {
                         user = db.Users.FirstOrDefault(u => u.Id == session.UserId);
                    }

                    if (user != null)
                    {
                         return new UserResp()
                         {
                              UserId = user.Id,
                              Status = true,
                              Role = user.Level,
                              Name = user.Username
                         };
                    }
               }

               //if user does not exist
               return new UserResp()
               {
                    Status = false,
               };
          }
     }
}


