using Ibrahim_MVC_Frist.Models;

namespace Ibrahim_MVC_Frist.Repository.Base
{
    public interface IRepoProduct : IRepository<Product>
    {
       
        IEnumerable<Product> FindAllProducts();
      
    }
}
