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
using eUseControl.BusinessLogic.DBModel;
using Microsoft.AspNetCore.Http;




namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Constructor to inject IHttpContextAccessor
        public UserApi(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string RegisterUser(UDataRegister model)
        {
            using (var db = new UserContext())
            {
                if (db.Users.Any(u => u.Username == model.Name || u.Email == model.Email))
                    return null;

                var user = new UDbTable
                {
                    Email = model.Email,
                    Password = LogRegHelper.HashPassword(model.Password),
                    LastLogin = model.RegisterDataTime,
                    LastIp = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
                    Role = URole.User
                };

                db.Users.Add(user);
                db.SaveChanges();

                // Generate a token for the user
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
                    // Check if the user exists in the database
                    user = dbContext.Users.FirstOrDefault(u => u.Email == model.NameOrEmail);

                    if (user == null)
                    {
                        return new UserResp
                        {
                            Status = false,
                            Result = LogInResult.EmailNotFound
                        };
                    }

                    // Incorrect password
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

                // Fix for CS0120: Use the injected IHttpContextAccessor instance
                user.LastIp = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();

                using (var db = new UserContext())
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }

                // Generate a response for the user
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
    }
}