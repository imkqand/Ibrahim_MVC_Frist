using Microsoft.AspNetCore.Mvc;

namespace Ibrahim_MVC_Frist.Controllers
{
    public class HomeEmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
