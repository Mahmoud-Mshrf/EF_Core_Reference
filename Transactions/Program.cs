using Microsoft.EntityFrameworkCore;

namespace Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();
            //FullWorkTransaction(context);
            //NotWorkTranaction(context);
            //TransactionWithSavePoint(context);
        }

        private static void TransactionWithSavePoint(AppDbContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Books.Add(new Book { Name = "Test Book From Transaction 3" });
                    context.Books.Add(new Book { Name = "Test Book From Transaction 4" });
                    context.SaveChanges();
                    transaction.CreateSavepoint("FirstPoint");

                    // The Two Following Lines Will Throw exception this mean not work so if we don't make savepoint all the transaction will not commit but we commit to the savepoint
                    context.Books.Add(new Book { Id=15, Name = "Test Book From Transaction 5" });
                    context.Books.Add(new Book { Id=16, Name = "Test Book From Transaction 61" });
                    transaction.Commit();
                }
                catch
                {
                    transaction.RollbackToSavepoint("FirstPoint");// this make the code return to the save point
                    transaction.Commit();// this make the code commit at the last point so here it at the savePoint(FirstPoint) and commit so what before the savePoint will commited
                    throw;
                }
            }
        }

        private static void NotWorkTranaction(AppDbContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // WorkLine:
                    context.Books.Add(new Book { Name = "Test Book From Transaction 1" });
                    context.SaveChanges();
                    // Not WorkLine so the all transaction not commit:
                    context.Books.Add(new Book {Id = 10, Name = "Test Book From Transaction 2" });
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private static void FullWorkTransaction(AppDbContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Books.Add(new Book { Name = "Test Book From Transaction 1" });
                    context.SaveChanges();
                    context.Books.Add(new Book { Name = "Test Book From Transaction 2" });
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
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