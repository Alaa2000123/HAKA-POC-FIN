using Connecter.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult SignIn()
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Append("User", $"", options);
      
            return View();
        }
        public IActionResult Check(UserLogin userLogin)
        {
            if(userLogin.UserName == "Admin" && userLogin.Password =="admin")
            {
               
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Append("User", $"Admin", options);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
         
        }
    }
}
