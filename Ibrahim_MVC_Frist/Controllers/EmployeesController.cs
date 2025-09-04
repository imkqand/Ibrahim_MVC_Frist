using Ibrahim_MVC_Frist.Data;
using Ibrahim_MVC_Frist.Filters;
using Ibrahim_MVC_Frist.Models;
using Ibrahim_MVC_Frist.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace Ibrahim_MVC_Frist.Controllers
{
    [SessionAuthorize]
    public class EmployeesController : Controller
    {


        //private readonly ApplicationDbContext _context;
        //private readonly IRepository<Employee> _repository;

       // private readonly IRepoEmployee _repoEmployee;


       private readonly IUnitOfWork _unitOfWork;

        //public CategoryController(ApplicationDbContext context, IRepository<Category> repository)
        //{
        //    _context = context;
        //    _repository = _repository;
        //}

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
           // var emps = _context.employeesm.ToList();
            var emps = _unitOfWork.Employee.FindAll().ToList();
            return Ok(emps);
        }

        [HttpGet]
        public IActionResult Index()
        {
            // IEnumerable<Employee> emps = _context.employeesm.ToList();
            IEnumerable<Employee> emps = _unitOfWork.Employee.FindAllEmployee().ToList();


            if (emps.Any())
            {
                TempData["Success"] = "تم جلب البيانات ";
            }
            else
            {
                TempData["Error"] = "لا توجد بيانات";
            }

            return View(emps);

          
        }

        [HttpGet]
        public IActionResult create()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Create(Employee empl)
        {
            if (empl.Name == "100")
            {
                ModelState.AddModelError("custumErorr", "Name can not be Equal 100");
            }


            if (ModelState.IsValid)
            {
                //_context.employeesm.Add(empl);
                //_context.SaveChanges();
                _unitOfWork.Employee.Add(empl);
                _unitOfWork.Save();
                TempData["Add"] = "تم اضافة البيانات بنجاح";
                return RedirectToAction("Index");
            }
            else { return View(empl); }


           

        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
           // var emps = _context.employeesm.Find(Id);
            var emps = _unitOfWork.Employee.FindById(Id);
            return View(emps);
        }

        [HttpPost]
        public IActionResult Edit(Employee emps)
        {
            //_context.employeesm.Update(emps);
            //_context.SaveChanges();
            _unitOfWork.Employee.Update(emps);
            _unitOfWork.Save();
            TempData["Update"] = "تم تحديث البيانات بنجاح";
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
           // var emps = _context.employeesm.Find(Id);
            var emps = _unitOfWork.Employee.FindById(Id);
            return View(emps);
        }

        [HttpPost]
        public IActionResult DeletePost(int Id)
        {

            //_context.employeesm.Remove(emps);
            //_context.SaveChanges();
            //_unitOfWork.Employee.Delete(emps);
            //_unitOfWork.Save();

            var emps = _unitOfWork.Employee.FindById(Id);
            emps.IsDelete = true;
            _unitOfWork.Employee.Update(emps);
            _unitOfWork.Save();
            TempData["Remove"] = "تم حذف البيانات بنجاح";
            return RedirectToAction("Index");

        }

      



    }
}
