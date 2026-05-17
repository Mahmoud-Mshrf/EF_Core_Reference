using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeedingData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SeedData();
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();

                foreach (var item in context.Blogs)
                {
                    Console.WriteLine(item.Url);
                }
                
            }
        }
        public static void SeedData()
        {
            using(var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                
                var blog = context.Blogs.FirstOrDefault(b=>b.Url== "WWW.FaceBook.com");
                if (blog == null)
                    context.Blogs.Add(new Blog { Url = "WWW.FaceBook.com" });
                context.SaveChanges();
            }
        }
    }
    public class AppDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS;Initial Catalog= Ef_Examples ;Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    public class Blog
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }
    [Table("Posts")]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}