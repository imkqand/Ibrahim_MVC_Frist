using Ibrahim_MVC_Frist.Models;

namespace Ibrahim_MVC_Frist.Repository.Base
{
    public interface IRepoCategory : IRepository<Category>
    {
        IEnumerable<Category> FindAllCategory();
    }
}
