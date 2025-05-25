using System;
using System.Web;
using System.Data.Entity;
using System.Linq;
using CryptoWallet.BusinessLogic.DBModel;
using CryptoWallet.Domain.Entities.Session;
using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Domain.Entities.User.UserActionResponse;
using CryptoWallet.Domain.Enums;
using CryptoWallet.Helpers.RegFlow;
using CryptoWallet.BusinessLogic.DBModel;
using Microsoft.AspNetCore.Http;
using CryptoWallet.Domain.Entities.User.Reg;
using CryptoWallet.Domain.User.Reg;
using CryptoWallet.Domain.User.Auth;




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
        internal UserRegDataResp SetRegisterUserAction(RegDataActionDTO local)
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
                    Error = "This Username a exists"
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
    }
}