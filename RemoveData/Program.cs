using Microsoft.EntityFrameworkCore;

namespace RemoveData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                //RemoveItem(context);
                //RemoveRange(context);
                RemoveItemWithRelatedData(context);
            }
        }

        private static void RemoveItemWithRelatedData(AppDbContext context)
        {
            // The default Behaviour for the EntityFramework Core that OnDeleteCascade if there are parent element and we want to delete it it also will delete the childs of this parent 
            // OnDelete Restrect : it refuse to delete the parent because it have childs and if it don't have childs it will be removed if we remove it
            // OnDelete SetNull : if we want to remove the parent and it have Childs it will remove the parent and make its value in Childs equal null but must we make it Property Nullable in childs 
            

        }   

        private static void RemoveItem(AppDbContext context)
        {
            var book = context.Books.Find(11);
            context.Books.Remove(book);
        }
        private static void RemoveRange(AppDbContext context)
        {
            var books = context.Books.Where(b => b.Id >= 5 && b.Id <= 7).ToList();
            context.Books.RemoveRange(books);
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
            modelBuilder.Entity<Author>().
                HasMany(x => x.Books).
                WithOne(x => x.Author).
                OnDelete(DeleteBehavior.Restrict);
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