namespace Login.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Login.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Login.Models.UserDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Login.Models.UserDBContext context)
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
            List<User> user = new List<User>();
            user.Add(new User() { name = "angel", surname = "silva", lastname = "borja", usr = "angelsilva", pwd = "pwd1234", userType = true, regDate = DateTime.Now });
            user.Add(new User() { name = "lorenzo", surname = "chachon", lastname = "foobar", usr = "lorenzo", pwd = "pwd1234", userType = false, regDate = DateTime.Now });
            user.Add(new User() { name = "otman", surname = "licona", lastname = "ledezma", usr = "otman", pwd = "pwd1234", userType = false, regDate = DateTime.Now });
            foreach (var item in user) {
                context.Users.Add(item);
            }
            base.Seed(context);

        }
    }
}
