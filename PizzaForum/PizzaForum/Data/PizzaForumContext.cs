namespace PizzaForum.Data
{
    using System.Data.Entity;
    using Models;

    public class PizzaForumContext : DbContext
    {
        public PizzaForumContext()
            : base("PizzaForumContext")
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Reply> Replies { get; set; }

    }


}