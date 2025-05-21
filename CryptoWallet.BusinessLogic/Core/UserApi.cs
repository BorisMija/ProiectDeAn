using System;
using System.Data.Entity;
using System.Linq;
using CryptoWallet.BusinessLogic.DBModel;
using CryptoWallet.Domain.Entities.Session;
using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Domain.Entities.User.UserActionResponse;
using CryptoWallet.Domain.Enums;
using CryptoWallet.Helpers.RegFlow;
using eUseControl.BusinessLogic.DBModel;
using Microsoft.AspNetCore.Http;




namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        public string RegisterUser(UDataRegister model)
        {
            using (var db = new UserContext())
            {
                if (db.Users.Any(u => u.Name == model.Name || u.Email == model.Email))
                    return null;

                var user = new UDbTable
                {

                    Email = model.Email,
                    Password = LogRegHelper.HashPassword(model.Password),
                    LastLogin = model.RegisterDataTime,
                    LastIp = HttpContext.Current?.Request.UserHostAddress,
                    Level = URole.User
                };

                db.Users.Add(user);
                db.SaveChanges();

                // Generam un token pentru utilizator
                string token = LogRegHelper.GenerateSecureToken(user.Id);

                return token;
            }
        }

        public UserResp LogInUser(ULoginData model)
        {
            try
            {
                string hashedPassword = LogRegHelper.HashPassword(model.Password);
                UDbTable user;

                using (var dbContext = new UserContext())
                {
                    // Existenta utilizatorului in baza de date
                    user = dbContext.Users.FirstOrDefault(u => u.Email == model.NameOrEmail);

                    if (user == null)
                    {
                        return new UserResp
                        {
                            Status = false,
                            Result = LogInResult.EmailNotFound
                        };
                    }

                    // Parola incorecta
                    if (user.Password != hashedPassword)
                    {
                        return new UserResp
                        {
                            Status = false,
                            Result = LogInResult.WrongPassword
                        };
                    }
                }


                user.LastLogin = model.LoginDataTime;
                user.UserIp = HttpContext.Current?.Request.UserHostAddress;

                using (var db = new UserContext())
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }

                // Generam un Response pentru utilizator
                return new UserResp
                {
                    Status = true,
                    Result = LogInResult.Success,
                    UserId = user.Id,
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UserLogInLogic: {ex.Message}");
                return new UserResp
                {
                    Status = false,
                    Result = LogInResult.UnknownError,
                };
            }
        }

        public userCookieResponse GenerateCookieByUserAction(int userId)
        {
            var cookieString = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(userId + HttpContext.Current?.Request.UserHostAddress)
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

            //if session not exist
            else
            {
                // Insert table
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

            return new UserCookieResp()
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
                        Name = user.Name
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