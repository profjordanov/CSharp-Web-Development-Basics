using PizzaForum.Models;

namespace PizzaForum.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Category> Categories { get; }

        IRepository<Login> Logins { get; }

        IRepository<Reply> Replies { get; }

        IRepository<Topic> Topics { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}
