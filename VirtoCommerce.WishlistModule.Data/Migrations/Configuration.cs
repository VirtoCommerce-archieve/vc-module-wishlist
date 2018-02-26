using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace VirtoCommerce.WishlistModule.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<VirtoCommerce.WishlistModule.Data.Repositories.WishlistRepositoryImpl>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(VirtoCommerce.WishlistModule.Data.Repositories.WishlistRepositoryImpl context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
