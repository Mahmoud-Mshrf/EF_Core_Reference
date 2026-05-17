using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneToOneRelationShip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();
            var blog = context.Blogs.Include(b=>b.BlogImage).FirstOrDefault();
            Console.WriteLine(blog.BlogImage.Image);
        }
    }
    public class AppDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS;Initial Catalog=Ef_Relations; Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.BlogImage)
                .WithOne(i => i.Blog)
                .HasForeignKey<BlogImage>(b => b.BlogForeignKey);
        }
    }
    public class Blog
    {
        public int Id { get; set; }
        [Required ,MaxLength(500)]
        public string Url { get; set; }
        public BlogImage BlogImage { get; set; }
    }
    [Table("BlogImages")]
    public class BlogImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required ,MaxLength(500)]
        public string Caption { get; set; }
        public int BlogForeignKey { get; set; }
        public Blog Blog { get; set; }
    }
}