using Ibrahim_MVC_Frist.Data;
using Ibrahim_MVC_Frist.Dtos;
using Ibrahim_MVC_Frist.Filters;
using Ibrahim_MVC_Frist.Models;
using Ibrahim_MVC_Frist.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim_MVC_Frist.Controllers
{
    [SessionAuthorize]
    public class ProductController : Controller
    {

        // private readonly ApplicationDbContext _context;


        //public ProductController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}


        //private readonly IRepository<Product> _repository;
        //private readonly IRepository<Category> _repositoryCategory;
        //private readonly IRepoProduct _repoProduct;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController( IUnitOfWork unitOfWork)
        {

           // _repository = repository;
            //_repositoryCategory = repositoryCategory;
            //_repoProduct = repoProduct;
            _unitOfWork = unitOfWork;
        }

        private void CreateCategoryList()
        {
            // List<CategoryDto> categoryDtos = new List<CategoryDto> {
            //// new CategoryDto { Id = 0, Name = "Select Category"},
            // new CategoryDto { Id = 1, Name = "Elictronic"},
            // new CategoryDto { Id = 2, Name = "Clothing"},
            // new CategoryDto { Id = 3, Name = "Mobile"}
            //   };

            //List<Category> cat = _context.Categories.ToList();

            IEnumerable<Category> cat = _unitOfWork.Category.FindAll().ToList();
            SelectList selectListItems = new SelectList(cat, "Id", "Name", 0);
            ViewBag.categoryDtos = selectListItems;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
        //    var products =
        //        _context.Products
        //        .Include(e => e.Category)
        //        .AsNoTracking() // تعمل asNoTraking اذا فيه بيانات في الصفحه ما تبغى تعدلها الا من الادمن فقط اما اذا فيه بيانات تتعدل لازم ما تسوي نوت تراك
        //        .Select(p=> new ProductDto
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //            Description = p.Description,
        //            Price = p.Price,
        //            Quantity = p.Quantity,
        //            CategoryId = p.CategoryId

        //        })
        //        .ToList();

                var products = _unitOfWork.Product.FindAllProducts().ToList();
            return Ok(products);
        }

        [HttpGet]
        public IActionResult Index()
        {
            //IEnumerable<Product> Products = _context.Products.Include(e => e.Category).ToList();
            IEnumerable<Product> Products = _unitOfWork.Product.FindAllProduct().ToList(); 

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

            CreateCategoryList();
            return View();
           
        }

        [HttpPost]
        public IActionResult create(Product Products)
        {
            if (Products.Name == "100")
            {
                ModelState.AddModelError("custumErorr", "Name can not be Equal 100");
            }



            if (ModelState.IsValid)
            {
                //_context.Products.Add(Products);
                //_context.SaveChanges();
                _unitOfWork.Product.Add(Products);
                _unitOfWork.Save();
                TempData["Add"] = "تم اضافة البيانات بنجاح";
                return RedirectToAction("Index");
            }
            else { return View(Products); }

           

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //var products = _context.Products.Find(Id);
            var products = _unitOfWork.Product.FindById(Id);
            CreateCategoryList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Edit(Product products)
        {
            //_context.Products.Update(products);
            //_context.SaveChanges();
            _unitOfWork.Product.Update(products);
            _unitOfWork.Save();
            TempData["Update"] = "تم تحديث البيانات بنجاح";
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            //var products = _context.Products.Find(Id);
            var products = _unitOfWork.Product.FindById(Id);
            CreateCategoryList();
            return View(products);
        }

        [HttpPost]
        public IActionResult DeletePost(int Id)
        {
            //_context.Products.Remove(products);
            //_context.SaveChanges();
            //_unitOfWork.Product.Delete(products);


            var Pro = _unitOfWork.Product.FindById(Id);
            Pro.IsDelete = true;
            _unitOfWork.Product.Update(Pro);
            _unitOfWork.Save();
           
            TempData["Remove"] = "تم حذف البيانات بنجاح";
            return RedirectToAction("Index");

        }

    }
}
