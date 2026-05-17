using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedingData
{
    internal class Instructions
    {
        /*
         * How to insert data into a table in db :
         * Creating Custom Method:
         * public static void SeedData()
         * {
         *     using(var context = new AppDbContext())
         *     {
         *         context.Database.EnsureCreated();
         *         
         *         var blog = context.Blogs.FirstOrDefault(b=>b.Url== "WWW.FaceBook.com");
         *         if (blog == null)
         *             context.Blogs.Add(new Blog { Url = "WWW.FaceBook.com" });
         *         context.SaveChanges();
         *     }
         * }
         * Using FluentAPI :
         * modelBuilder.Entity<Blog>().HasData(new Blog {Id=5,Url = "WWW.FaceBook.com"} ) 
         * Note : using FluentAPI must give value to the primarykey Because Here is not given implicitly
         */
    }
}
