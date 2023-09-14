﻿using Connecter.Client;
using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IClientContainer _client;
        public LoginController(IClientContainer client)
        {
            _client = client;
        }
        public IActionResult SignIn()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append("User", $"", options);
      
            return View();
        }
        public IActionResult Check(UserLogin userLogin)
        {
            if (userLogin.UserName == "Admin" && userLogin.Password == "admin")
            {

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append("User", $"Admin", options);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                if (userLogin.UserName.ToLower() == "qusai")
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Append("User", $"1", options);

                }
                else if (userLogin.UserName.ToLower() == "alaa")
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Append("User", $"2", options);

                }
                else
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Append("User", $"3", options);

                }
                return RedirectToAction("Index", "Home");
            }

        }
    }
}
