namespace Ibrahim_MVC_Frist.Repository.Base
{
    public interface IUnitOfWork
    {
        IRepoEmployee Employee { get; }
        IRepoCategory Category { get; } 
        IRepoProduct Product { get; }

        void Save();


    }
}
