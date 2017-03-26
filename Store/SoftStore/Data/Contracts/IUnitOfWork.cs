using SoftStore.Models;

namespace SoftStore.Data.Contracts
{
    public interface IUnitOfWork
    {
        int SaveChanges();

        IRepository<Game> Games { get;}

        IRepository<Login> Logins { get; }

        IRepository<User> Users { get; }     
    }
}
