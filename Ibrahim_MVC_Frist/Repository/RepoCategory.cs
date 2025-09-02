using Ibrahim_MVC_Frist.Data;
using Ibrahim_MVC_Frist.Models;
using Ibrahim_MVC_Frist.Repository.Base;

namespace Ibrahim_MVC_Frist.Repository
{
    public class RepoCategory : MainRepository<Category> , IRepoCategory
    {
        private readonly ApplicationDbContext _context;

        public RepoCategory(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public IEnumerable<Category> FindAllCategory()
        {

         return   _context.Categories.ToList();
        }
    }
}
