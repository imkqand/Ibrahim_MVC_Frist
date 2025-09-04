using Ibrahim_MVC_Frist.Models;

namespace Ibrahim_MVC_Frist.Repository.Base
{
    public interface IRepoEmployee : IRepository<Employee>
    {
            Employee Login(string username, string password);
        public IEnumerable<Employee> FindAllEmployee();


    }
}
