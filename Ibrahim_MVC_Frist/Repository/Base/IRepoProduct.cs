using Ibrahim_MVC_Frist.Models;
using Microsoft.EntityFrameworkCore;

namespace Ibrahim_MVC_Frist.Repository.Base
{
    public interface IRepoProduct : IRepository<Product>
    {
       
        IEnumerable<Product> FindAllProducts();

        public IEnumerable<Product> FindAllProduct();

    }
}
