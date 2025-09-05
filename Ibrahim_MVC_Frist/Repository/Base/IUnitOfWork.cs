using Ibrahim_MVC_Frist.Models;

namespace Ibrahim_MVC_Frist.Repository.Base
{
    public interface IUnitOfWork
    {
        IRepoEmployee Employee { get; }
        IRepoCategory Category { get; } 
        IRepoProduct Product { get; }

        IRepository<Permission> Permissions { get; }

        void Save();


    }
}
