using Microsoft.EntityFrameworkCore;

namespace UpdateData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // There are 3 Methods to Update data :
                //Update1(context);
                //Update2(context);
                //Update3(context);
                //ChangeDataAndKeepData(context);
                //UpdateMultipleElement(context);
            }
            
        }

        private static void UpdateMultipleElement(AppDbContext context)
        {
            var books = context.Books.Where(b=>b.AuthorId==null).ToList();
            foreach (var book in books)
            {
                book.AuthorId = 1;
            }
            context.UpdateRange(books);
            context.SaveChanges();
        }

        private static void ChangeDataAndKeepData(AppDbContext context)
        {
            // Assume that i want to update some books names without change author

            // The following Code will change the name but also will change the author because it will give it the default value 
            //var book = new Book
            //{
            //    Id= 9,
            //    Name = "Edited Book"
            //};
            //context.Update(book);
            //context.SaveChanges();

            // here i will change the name of book without change the author

            var book = new Book
            {
                Id= 9,
                Name = "Edited Book"
            };
            context.Update(book);
            context.Entry(book).Property(b => b.AuthorId).IsModified = false;
            context.SaveChanges();
        }

        private static void Update1(AppDbContext context)
        {
            var book = context.Books.Find(13);
            book.Name = "Updated Book";
            context.SaveChanges();
        }

        private static void Update2(AppDbContext context)
        {
            // Here we make object that contain the primaryKey(id) of an existing element with changed information,
            // so when we use Update it put the new information on the element with the given primarykey
            var Nationality = new Nationality { Id = 2, Name = "Updated Nationality" };
            context.Update(Nationality);
            context.SaveChanges();
        }

        private static void Update3(AppDbContext context)
        {
            var CurrenntNationality = context.Nationalities.Find(3);
            var Nationality = new Nationality {Id=3, Name = "The Updated Nationality" };
            context.Entry(CurrenntNationality).CurrentValues.SetValues(Nationality);
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