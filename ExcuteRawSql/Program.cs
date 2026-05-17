using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ExecuteSqlRaw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();
            //WithSqlCode(context);
            //WithStoredProcedure(context);
        }

        private static void WithStoredProcedure(AppDbContext context)
        {
            var BookName = new SqlParameter("BookName", "MahmoudBook3");
            context.Database.ExecuteSqlRaw("InsertProcedure @BookName", BookName);
            // Or
            var BookNamee = "MahmoudBook2";
            context.Database.ExecuteSqlRaw($"InsertProcedure {BookNamee}");
        }

        private static void WithSqlCode(AppDbContext context)
        {
            // ExecuteSqlRaw   Excutes stored procedure or sql statements that don't return values that only affect the database inserting or deleting or any thing that don't return value
            // if we want to returnvalue we use FromSqlRaw
            context.Database.ExecuteSqlRaw("Insert into Books (Name) Values ('MahmoudBook')");
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