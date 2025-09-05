using Ibrahim_MVC_Frist.Models;
using Ibrahim_MVC_Frist.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ibrahim_MVC_Frist.Controllers
{
    public class PermissionController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public PermissionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }


        private void CreateEmployeeList()
        {

            IEnumerable<Employee> Emp = _unitOfWork.Employee.FindAll();
            SelectList selectListItems = new SelectList(Emp, "Id", "Name", 0);
            ViewBag.Emp = selectListItems;
        }



        public IActionResult Index()
        {
            CreateEmployeeList();
            var permission = _unitOfWork.Permissions.FindAll();
            return View(permission);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateEmployeeList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Permission permission)
        {

            if(ModelState.IsValid)
            {

                _unitOfWork.Permissions.Add(permission);
                _unitOfWork.Save();
                TempData["Add"] = "تم اضافة البيانات ";
                return RedirectToAction("Index");
            }

            return View();

        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Permission permission)
        {
            _unitOfWork.Permissions.Update(permission);
            _unitOfWork.Save();

            TempData["Update"] = "تم تحديث البيانات ";
            return RedirectToAction("Index");
        }
    }
}
