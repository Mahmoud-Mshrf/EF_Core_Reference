using Microsoft.EntityFrameworkCore;

namespace ManyToManyRelationship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF_Testt;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Posts)
                .UsingEntity<PostTag>(
                   j=>j
                      .HasOne(pt => pt.Tag)
                      .WithMany(t => t.PostTags)
                      .HasForeignKey(pt => pt.TagId),
                   j => j
                      .HasOne(pt => pt.Post)
                      .WithMany(p => p.PostTags)
                      .HasForeignKey(pt => pt.PostId),
                   j =>j
                      .HasKey(pt => new { pt.PostId, pt.TagId })
                      );
        }
    }
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public List<PostTag> PostTags { get; set; }
    }
    public class Tag
    {
        public string TagId { get; set; }
        public ICollection<Post> Posts { get; set;}
        public List<PostTag> PostTags { get; set; }

    }
    public class PostTag
    {
        public int PostId { get; set; }
        public string TagId { get; set; }

        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
    
}