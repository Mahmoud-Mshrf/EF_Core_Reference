using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GlobalQueryFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Global Query Filter : is a filter that be always applied over the entity 
            var context = new AppDbContext();
            var books = context.Books;
            foreach (var book in books) 
            {
                Console.WriteLine(book.Name);
            }
            // the filter has been applied on OnModelCreating Method Like this:
            // modelBuilder.Entity<Book>().HasQueryFilter(b => b.Name.Contains("R"));// this make it return only the books that have R in its name
            // to disable this filter on a specified query:
            var bookss = context.Books.IgnoreQueryFilters();
            foreach (var book in bookss)
            {
                Console.WriteLine(book.Name);
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasQueryFilter(b => b.Name.Contains("R"));// this make it return only the books that have R in its name
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