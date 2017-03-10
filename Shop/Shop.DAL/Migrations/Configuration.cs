namespace Shop.DAL.Migrations
{
    using LoginRegister.Models;
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

        protected override void Seed(ShopDBContext context) {
            var route = System.Environment.GetEnvironmentVariable("USERPROFILE") + @"\Source\Repos\SterlingMomentum\Shop\Shop.DAL\DBMockData";
            var sql = Directory.GetFiles(route).OrderBy(x => x);
            foreach (var item in sql) {
                context.Database.ExecuteSqlCommand(File.ReadAllText(item));
            }
        }
    }
}
