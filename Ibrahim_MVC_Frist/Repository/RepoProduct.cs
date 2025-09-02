using Ibrahim_MVC_Frist.Data;
using Ibrahim_MVC_Frist.Models;
using Ibrahim_MVC_Frist.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim_MVC_Frist.Repository
{
    public class RepoProduct : MainRepository<Product> , IRepoProduct
    {

        private readonly ApplicationDbContext _context;

        public RepoProduct(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }



        public IEnumerable<Product> FindAllProducts()
        {
            IEnumerable<Product> Products = _context.Products.Include(e => e.Category).ToList();
            return Products;
        }
    }
}
