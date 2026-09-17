using Microsoft.AspNetCore.Mvc;
using PREFINALS_QUIZ_PORTFOLIO.Models;

namespace PREFINALS_QUIZ_PORTFOLIO.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (model.Username == "Admin" && model.Password == "Admin123")
            {
                HttpContext.Session.SetString("User", model.Username);
                return RedirectToAction("Index", "Projects");
            }
            model.ErrorMessage = "Invalid Username or Password!";
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}