using CryptoWallet.BusinessLogic.Interfaces;
using CryptoWallet.BusinessLogic;
using CryptoWallet.Domain.Entities.User;
using CryptoWallet.Domain.Enums;
using CryptoWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CryptoWallet.Domain.Entities.User.UserActionResponse;

namespace CryptoWallet.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISession _session;
        private readonly IRegister _register;

        public AccountController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSessionBL();
            _register = bl.GetRegisterBL();
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            ViewBag.HideFooter = true;
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserDataRegister registerModel)
        {
            if (ModelState.IsValid)
            {
                var data = new UDataRegister
                {
                    Name = registerModel.Name,
                    Email = registerModel.Email,
                    Password = registerModel.Password,
                    ConfirmPassword = registerModel.ConfirmPassword,
                    RegisterDataTime = DateTime.Now
                };

                try
                {
                    // call BL for token
                    string token = _register.SignUpLogic(data);

                    //if succes, else...
                }
                catch
                (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    ModelState.AddModelError("", "An error occurred while registering. Please try again.");
                    return View(registerModel);
                }
                return RedirectToAction("Login");

            }

            return View(registerModel);
        }

        // GET: /Account/Login
        public ActionResult Login()
        {
            ViewBag.HideFooter = true;
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin loginModel)
        {
            if (ModelState.IsValid)
            {
                var data = new ULoginData
                {
                    NameOrEmail = loginModel.NameOrEmail,
                    Password = loginModel.Password,
                    LoginDateTime = DateTime.Now,
                };

                try
                {
                    // call BL for token
                    var userResp = _session.LogInLogic(data);

                    if (userResp.Status) //true
                    {
                        //Generarea unui cookie
                        UserCookieResponse userCookieResp = _session.GenerateCookieByUser(userResp.UserId);

                        HttpCookie cookie = userCookieResp.cookie;
                        Response.Cookies.Add(cookie);

                        return RedirectToAction("Index", "Home");
                    }

                    else //false
                    {
                        switch (userResp.Result)
                        {
                            case LogInResult.EmailNotFound:
                                TempData["ErrorMessage"] = "Nu exista utilizator cu asa nume.";
                                break;
                            case LogInResult.WrongPassword:
                                TempData["ErrorMessage"] = "Parola incorecta.";
                                break;
                            default:
                                TempData["ErrorMessage"] = "Incercati din nou";
                                break;
                        }
                        return View(loginModel);
                    }
                }

                catch (Exception ex)
                {
                    // Eroare la procesarea cererii
                    TempData["ErrorMessage"] = "A apărut o eroare în sistem. Vă rugăm să încercați mai târziu.";
                    // Loghează excepția pentru depanare
                    System.Diagnostics.Debug.WriteLine($"Error in SignUp: {ex.Message}");
                }
            }

            else
            {
                // Eroare pentru validarea mesajului
                TempData["ErrorMessage"] = "Datele nu sunt valide. Introduceti din nou";
            }
            return View(loginModel);
        }

        public ActionResult Logout()
        {
            // Sterge cookie-ul de autentificare
            if (Request.Cookies["X-KEY"] != null)
            {
                var cookie = new HttpCookie("X-KEY");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }

            // Sterge sesiunea
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");
        }
    }
}