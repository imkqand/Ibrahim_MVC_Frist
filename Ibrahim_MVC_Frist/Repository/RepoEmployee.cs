using Ibrahim_MVC_Frist.Data;
using Ibrahim_MVC_Frist.Models;
using Ibrahim_MVC_Frist.Repository.Base;

namespace Ibrahim_MVC_Frist.Repository
{
    public class RepoEmployee : MainRepository<Employee> , IRepoEmployee
    {
        private readonly ApplicationDbContext _context;

        public RepoEmployee(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

       public Employee Login (string username, string password )
        {
                var employee = _context.employeesm.FirstOrDefault( e => e.UserName == username && e.Password == password && e.Islock==false);
            return employee;
        }

    }
}
