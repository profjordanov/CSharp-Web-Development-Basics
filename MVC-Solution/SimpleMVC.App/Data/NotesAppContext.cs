namespace SimpleMVC.App.Data
{
    using Models;
    using System.Data.Entity;

    public class NotesAppContext : DbContext
    {
        public NotesAppContext()
            : base("NotesAppContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
    }
}