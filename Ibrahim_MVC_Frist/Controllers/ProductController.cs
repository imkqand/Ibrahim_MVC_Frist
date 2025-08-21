using Ibrahim_MVC_Frist.Data;
using Ibrahim_MVC_Frist.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ibrahim_MVC_Frist.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Product> Products = _context.Products.ToList().Where(e => e.Id < 50);

            if (Products.Any())
            {
                TempData["Success"] = "تم جلب البيانات ";
            }
            else
            {
                TempData["Error"] = "لا توجد بيانات";
            }

            return View(Products);
        }


        [HttpGet]
        public IActionResult create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult create(Product Products)
        {
            _context.Products.Add(Products);
            _context.SaveChanges();
            TempData["Add"] = "تم اضافة البيانات بنجاح";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var products = _context.Products.Find(Id);
            return View(products);
        }

        [HttpPost]
        public IActionResult Edit(Product products)
        {
            _context.Products.Update(products);
            _context.SaveChanges();
            TempData["Update"] = "تم تحديث البيانات بنجاح";
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var products = _context.Products.Find(Id);
            return View(products);
        }

        [HttpPost]
        public IActionResult Delete(Product products)
        {
            _context.Products.Remove(products);
            _context.SaveChanges();
            TempData["Remove"] = "تم حذف البيانات بنجاح";
            return RedirectToAction("Index");

        }

    }
}
