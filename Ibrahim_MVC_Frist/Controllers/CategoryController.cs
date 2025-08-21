using Ibrahim_MVC_Frist.Data;
using Ibrahim_MVC_Frist.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ibrahim_MVC_Frist.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
              var categoriess = _context.Categories.ToList();
            return Ok(categoriess);
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> category = _context.Categories.ToList().Where(e=>e.Id<50);
         


            if (category.Any())
            {
                TempData["Success"] = "تم جلب البيانات ";
            }
            else
            {
                TempData["Error"] = "لا توجد بيانات";
            }

            return View(category);
        }


        [HttpGet]
        public IActionResult create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult create(Category category)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["Add"] = "تم اضافة البيانات ";
                return RedirectToAction("Index");

            }

            return View(category);
            
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var cat = _context.Categories.Find(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            TempData["Update"] = "تم تحديث البيانات ";
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var cat = _context.Categories.Find(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["Remove"] = "تم حذف البيانات ";
            return RedirectToAction("Index");

        }
    }
}
