using SoftStore.Data.Contracts;
using SoftStore.Models;

namespace SoftStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private SoftStoreContext context;

        private IRepository<Game> games;
        private IRepository<Login> logins;
        private IRepository<User> users;

        public UnitOfWork()
        {
            this.context = Data.Context;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public IRepository<Game> Games
            => this.games ??
            (this.games = new Repository<Game>(this.context.Games));

        public IRepository<Login> Logins
            => this.logins ??
               (this.logins = new Repository<Login>(this.context.Logins));

        public IRepository<User> Users
            => this.users ??
               (this.users = new Repository<User>(this.context.Users));

    }
}
