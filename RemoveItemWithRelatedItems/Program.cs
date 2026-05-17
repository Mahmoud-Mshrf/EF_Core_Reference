using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RemoveItemWithRelatedItems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context = new AppDbContext())
            {
                //RemoveItemWithRelatedDataOnDeleteCascade(context);
                //OnDeleteRestrict(context);
                //OnDeleteSetNull(context);
            }
        }

        private static void OnDeleteSetNull(AppDbContext context)
        {
            // If i Change The OnDelete Behaviour from Cascade to SetNull the parent will be deleted and the childs they will have null in its value BUT  the foreignKey Property in the childs Must be Nullable
            // modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne(b => b.Blog).OnDelete(DeleteBehavior.SetNull);
            var youtubeBlog = context.Blogs.Find(2);
            context.Remove(youtubeBlog);// now the blog will be deleted if it blog have posts or Not and the posts will have null in the blogId value
            context.SaveChanges();
        }

        private static void OnDeleteRestrict(AppDbContext context)
        {
            // If i Change The Behaviour from Cascade to Restrict nothing will be deleted if the parent have childs
            // modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne(b => b.Blog).OnDelete(DeleteBehavior.Restrict);
            var youtubeBlog = context.Blogs.Find(2);
            context.Remove(youtubeBlog);// now nothing will be deleted if this blog have posts, if it doesn't have posts the blog will be deleted
            context.SaveChanges();
        }

        private static void RemoveItemWithRelatedDataOnDeleteCascade(AppDbContext context)
        {
            // The default Behaviour for the EntityFramework Core that OnDeleteCascade if there are parent element and we want to delete it it also will delete the childs of this parent 
            // OnDelete Restrect : it refuse to delete the parent because it have childs and if it don't have childs it will be removed if we remove it
            // OnDelete SetNull : if we want to remove the parent and it have Childs it will remove the parent and make its value in Childs equal null but must we make it Property Nullable in childs 

            var youtubeBlog= context.Blogs.Find(2);
            context.Remove(youtubeBlog);//it will be deleted and delete their childs because on the default behaviour (Cascade) it will delete the childs 
            context.SaveChanges();
        }
    }
    public class AppDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS;Initial Catalog= Ef_BlogsCrud ;Integrated Security=True;TrustServerCertificate=True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne(b => b.Blog).OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class Blog
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}