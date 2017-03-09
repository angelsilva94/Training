namespace Shop.DAL.Migrations
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
            ContextKey = "LoginRegister.Models.ShopDBContext";
        }

        protected override void Seed(LoginRegister.Models.ShopDBContext context)
        {
            var route = @"C:\Users\Angel.silva\Source\Repos\SterlingMomentum\Shop\Shop.DAL\DBMockData";
            var sql = Directory.GetFiles(route).OrderBy(x => x);
            foreach (var item in sql) {
                context.Database.ExecuteSqlCommand(File.ReadAllText(item));
            }
        }
    }
}
