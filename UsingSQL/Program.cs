using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace UsingSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                //RawSql(context);
                //StoredProcedure(context);
                StoredProcedureWithParameter(context,2);
            }
        }

        private static void StoredProcedureWithParameter(AppDbContext context, int id)
        {
            //var BookDTo = context.BooksDTO.FromSqlRaw($"BookWithAuthorWithId {id}");
            //foreach (var book in BookDTo)
            //{
            //    Console.WriteLine(book.BookName + "Was Written By " + book.AuthorName);
            //}
            // Or 
            var BookId = new SqlParameter("Id", id);
            var BookDTo = context.BooksDTO.FromSqlRaw($"BookWithAuthorWithId @Id",BookId);
            foreach (var book in BookDTo)
            {
                Console.WriteLine(book.BookName + "Was Written By " + book.AuthorName);
            }
        }

        private static void StoredProcedure(AppDbContext context)
        {
            var BookDTo = context.BooksDTO.FromSqlRaw("BookWithAuthorProcedure");
            foreach (var book in BookDTo)
            {
                Console.WriteLine(book.BookName+"Was Written By "+book.AuthorName);
            }
        }

        private static void RawSql(AppDbContext context)
        {
            var Books = context.Books.FromSqlRaw("select * from Books");
            foreach (var book in Books)
            {
                Console.WriteLine(book.Name);
            }
        }
    }

    public class BookDTO
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
    }
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<BookDTO> BooksDTO { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS;Initial Catalog= Ef_Books ;Integrated Security=True;TrustServerCertificate=True;");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookDTO>().ToView("BookWithAuthor").HasNoKey();
            // or
            // modelBuilder.Entity<BookDTO>().ToView(null).HasNoKey();
            modelBuilder.Entity<BookDTO>().ToView("BookWithAuthorWithId").HasNoKey();
            // Or
            // modelBuilder.Entity<BookDTO>().ToFunction("BookWithAuthorWithId").HasNoKey();
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