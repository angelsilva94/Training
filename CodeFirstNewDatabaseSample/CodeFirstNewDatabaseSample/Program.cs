using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabaseSample {
    class Program {
        static void Main(string[] args) {
            using(var db = new BloggingContext()) {
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                db.blogs.Add(new Blog { Name = name });
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query) {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

            }
        }
    }
}
