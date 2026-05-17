using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Tracking_NoTracking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Entity FrameworkCore by default it tracks any changes happen on the elements in that returned by the context 
            using(var context = new AppDbContext())
            {
                var book = context.Books.First();// Entity FrameworkCore Track this element and any changes happen to it
                book.Name = "Friends For Ever";// Entity FrameworkCore will record this change 
                context.SaveChanges();

                // but tracking by entity frameworkCore affect the performance so sometimes we don't need this for examble when select data just for showing it and no changes will happen to it so the tracker doesn't have any benefit
                // so if we just show the data and don't change it so we can disable this tracker 
                
                var book2 = context.Books.AsNoTracking().First();
                book.Name = "Football With Life";
                context.SaveChanges();
                // so the change will not affect the database




                // we can apply the noTracking over all the session with the db:
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;



                // we can show all the trackers that exists in this session :
                var trackers = context.ChangeTracker.Entries();
                foreach (var item in trackers)
                {
                    Console.WriteLine($"{item.Entity.ToString()} - {item.State}");
                }
            }
            
        }
    }
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS;Initial Catalog= Ef_Books ;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }

    }
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NationalityId { get; set; }
    }
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}