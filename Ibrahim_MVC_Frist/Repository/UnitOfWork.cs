using Ibrahim_MVC_Frist.Data;
using Ibrahim_MVC_Frist.Repository.Base;

namespace Ibrahim_MVC_Frist.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Employee = new RepoEmployee(_context);
            Product = new RepoProduct(_context);
            Category = new RepoCategory(_context);



        }


        public IRepoEmployee Employee { get; }

        public IRepoCategory Category { get; }

        public IRepoProduct Product { get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
