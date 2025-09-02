using Ibrahim_MVC_Frist.Models;

namespace Ibrahim_MVC_Frist.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();

        T FindById(int id);

        void Add(T Entity);
        void Update(T Entity); 
        void Delete(T Entity);
        IEnumerable<Category> FindAllCategory();
    }
}
