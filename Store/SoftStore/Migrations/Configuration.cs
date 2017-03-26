namespace SoftStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SoftStore.Data.SoftStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SoftStore.Data.SoftStoreContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SoftStore.Data.SoftStoreContext context)
        {     
        }
    }
}
