using PizzaForum.Models;

namespace PizzaForum.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PizzaForumContext : DbContext
    {
      
        public PizzaForumContext()
            : base("PizzaForumContext")
        {
        }

        public DbSet<Category>  Categories { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Replies> Replies { get; set; }


    }


}