using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace AddData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                //AddBook(context);
                //AddAuthor(context);
                //AddNationality(context);
                //AddBookWithNewAuthor(context);
                //AddAuthorWithListOfBooks(context);
                //AddAuthorWithNationality(context);
                //addRangeBooks(context);
            }
        }

        private static void addRangeBooks(AppDbContext context)
        {
            List<Book> books = new List<Book>
            {
                new Book { Name = "New Book 1"},
                new Book { Name = "New Book 2"},
                new Book { Name = "New Book 3"},
                new Book { Name = "New Book 4"},
            };
            context.Books.AddRange(books);
            context.SaveChanges();
        }

        private static void AddAuthorWithNationality(AppDbContext context)
        {
            var Author = new Author
            {
                Name = "Good Author",
                Nationality= new Nationality {  Name = "Emirates"}
            };
            context.Authors.Add(Author);
            context.SaveChanges();
        }

        private static void AddAuthorWithListOfBooks(AppDbContext context)
        {
            var Author = new Author
            {
                Name = "Great Author",
                Books= new List<Book>
                {
                    new Book {Name = "Book 1"},
                    new Book {Name = "Book 2"},
                    new Book {Name = "Book 3"},
                    new Book {Name = "Book 4"}
                }
            };
            context.Authors.Add(Author);
            context.SaveChanges();
        }

        private static void AddBookWithNewAuthor(AppDbContext context)
        {
            var book = new Book
            {
                Name = "New Book",
                Author= new Author {  Name = "New Author"}
            };
            context.Books.Add(book);
            context.SaveChanges();
        }

        private static void AddNationality(AppDbContext context)
        {
            var Nationality = new Nationality
            {
                Name = "Egypt"
            };
            context.Nationalities.Add(Nationality);
            context.SaveChanges();
        }

        private static void AddAuthor(AppDbContext context)
        {
            var Author = new Author
            {
                Name = "Mahmoud"

            };
            context.Authors.Add(Author);
            context.SaveChanges();
        }

        private static void AddBook(AppDbContext context)
        {
            var book = new Book
            {
                Name = "Test"
            };
            context.Books.Add(book);
            context.SaveChanges();
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
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS;Initial Catalog= Ef_BooksCrud ;Integrated Security=True;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
    }
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? NationalityId { get; set; }
        public ICollection<Book> Books { get; set; }
        public Nationality Nationality { get; set; }    
    }
    public class Nationality
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
}