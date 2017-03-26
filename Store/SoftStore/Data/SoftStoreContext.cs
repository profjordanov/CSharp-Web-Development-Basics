using SoftStore.Models;

namespace SoftStore.Data
{
    using System.Data.Entity;

    public class SoftStoreContext : DbContext
    {
        public SoftStoreContext()
            : base("SoftStore")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasMany(game => game.Owners).WithMany(user => user.Games);
        }
    }
}