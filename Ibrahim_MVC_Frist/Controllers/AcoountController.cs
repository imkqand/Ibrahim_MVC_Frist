using Microsoft.AspNetCore.Mvc;

namespace Ibrahim_MVC_Frist.Controllers
{
    public class AcoountController : Controller
    {
        public IActionResult Logout()
        {

            return View("Login");

        }
        public IActionResult Login()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "Admin" && password == "123")
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Error";
            return View();
        }
    }
}
