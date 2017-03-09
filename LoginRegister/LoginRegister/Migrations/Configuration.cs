namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LoginRegister.Models.ShopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LoginRegister.Models.ShopDBContext context)
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
            var route = "C:\\Users\\Angel Silva\\Source\\Repos\\SterlingMomentum\\LoginRegister\\LoginRegister\\DBMockData";
            var sql = Directory.GetFiles(route).OrderBy(x => x);
            foreach (string item in sql) {
                context.Database.ExecuteSqlCommand(File.ReadAllText(item));
            }
        }
    }
}
