using Ibrahim_MVC_Frist.Repository.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ibrahim_MVC_Frist.Controllers
{
    public class AcoountController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public AcoountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");

        }
        public IActionResult Login()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var emp = _unitOfWork.Employee.Login(username, password);
            if (emp != null)
            {

                HttpContext.Session.SetString("Username", emp.Name);
                HttpContext.Session.SetInt32("Id", emp.Id);
                return RedirectToAction("Index", "Home");


            }


            //if (username == "Admin" && password == "123")
            //{
            //    HttpContext.Session.SetString("Username", username);
            //    return RedirectToAction("Index", "Home");
            //}
            ViewBag.Error = "خطاء في كلمة المرور أو إسم المستخدم";
            return View();
        }
    }
}
