using PizzaForum.Data.Contracts;
using PizzaForum.Data.Repositories;
using PizzaForum.Models;

namespace PizzaForum.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PizzaForumContext context;
        private IRepository<Category> categories;
        private IRepository<Login> logins;
        private IRepository<Reply> replies;
        private IRepository<Topic> topics;
        private IRepository<User> users;

        public UnitOfWork()
        {
            this.context = Data.Context;
        }

        public IRepository<Category> Categories
            => this.categories ?? (this.categories = new Repository<Category>(this.context.Categories));

        public IRepository<Login> Logins
            => this.logins ?? (this.logins = new Repository<Login>(this.context.Logins));

        public IRepository<Reply> Replies
            => this.replies ?? (this.replies = new Repository<Reply>(this.context.Replies));

        public IRepository<Topic> Topics
            => this.topics ?? (this.topics = new Repository<Topic>(this.context.Topics));

        public IRepository<User> Users
            => this.users ?? (this.users = new Repository<User>(this.context.Users));

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
