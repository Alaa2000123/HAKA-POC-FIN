using Connecter.Client;
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
            if (userLogin.UserName == "Admin")
            {

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append("User", $"Admin", options);
                return RedirectToAction("IDashboard", "Home");
            }
            else if(userLogin.UserName == "Manager")
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append("User", $"Manager", options);
                return RedirectToAction("IDashboard", "Home");
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
                else if (userLogin.UserName.ToLower() == "raya")
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Append("User", $"3", options);

                }
                else
                {
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Append("User", $"", options);
                    return RedirectToAction("SignIn");
                }
                return RedirectToAction("Welcomepage", "Home");
            }

        }
    }
}
