using Ibrahim_MVC_Frist.Data;
using Ibrahim_MVC_Frist.Dtos;
using Ibrahim_MVC_Frist.Models;
using Ibrahim_MVC_Frist.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim_MVC_Frist.Controllers
{
    public class CategoryController : Controller
    {
       // private readonly ApplicationDbContext _context;
       // private readonly IRepository<Category> _repository;
        private readonly IRepoCategory _repoCategory;

        //public CategoryController(ApplicationDbContext context, IRepository<Category> repository)
        //{
        //    _context = context;
        //    _repository = _repository;
        //}



        public CategoryController(IRepoCategory repoCategory)
        {
          
           _repoCategory = repoCategory;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            //var categoriess = _context.Categories.ToList();
            var categoriess = _repoCategory.FindAllCategory();
            return Ok(categoriess);
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    IEnumerable<Category> category = _context.Categories.ToList();



        //    if (category.Any())
        //    {
        //        TempData["Success"] = "تم جلب البيانات ";
        //    }
        //    else
        //    {
        //        TempData["Error"] = "لا توجد بيانات";
        //    }

        //    return View(category);
        //}

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> category = _repoCategory.FindAllCategory();



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

        //[HttpPost]
        //public IActionResult create(Category category)
        //{
        //    //try
        //    //{
        //    //    if (category.Name == "100")
        //    //    {
        //    //        ModelState.AddModelError("custumErorr", "Name can not be Equal 100");
        //    //    }

        //    //    if (ModelState.IsValid)
        //    //    {
        //    //        category.Name = null;
        //    //        _context.Categories.Add(category);
        //    //        _context.SaveChanges();
        //    //        TempData["Add"] = "تم اضافة البيانات ";
        //    //        return RedirectToAction("Index");
        //    //    }
        //    //    else { return View(category); }

        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    ModelState.AddModelError("" , " حدث خطاء اثناء تحميل البيانات :"+ e.Message);
        //    //    return View(category);

        //    //}


        //    if (category.Name == "100")
        //    {
        //        ModelState.AddModelError("custumErorr", "Name can not be Equal 100");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _context.Categories.Add(category);
        //        _context.SaveChanges();
        //        TempData["Add"] = "تم اضافة البيانات ";
        //        return RedirectToAction("Index");
        //    }
        //    else { return View(category); }

        //}


        [HttpPost]
        public IActionResult create(Category category)
        {

            if (category.Name == "100")
            {
                ModelState.AddModelError("custumErorr", "Name can not be Equal 100");
            }

            if (ModelState.IsValid)
            {
                _repoCategory.Add(category);
                TempData["Add"] = "تم اضافة البيانات ";
                return RedirectToAction("Index");
            }
            else { return View(category); }

        }



        [HttpGet]
        public IActionResult Edit(int Id)
        {
           // var cat = _context.Categories.Find(Id);
            var cat = _repoCategory.FindById(Id);
            return View(cat);
        }



        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //_context.Categories.Update(category);
            //_context.SaveChanges();
            _repoCategory.Update(category);
            TempData["Update"] = "تم تحديث البيانات ";
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            //var cat = _context.Categories.Find(Id);
            var cat = _repoCategory.FindById(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            //_context.Categories.Remove(category);
            //_context.SaveChanges();
            _repoCategory.Delete(category);
            TempData["Remove"] = "تم حذف البيانات ";
            return RedirectToAction("Index");

        }
    }
}
