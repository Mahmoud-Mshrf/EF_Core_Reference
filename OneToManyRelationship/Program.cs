using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace OneToManyRelationship
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
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=Ef_Relations;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne(p => p.Blog);
            //modelBuilder.Entity<Post>().HasOne(p=>p.Blog).WithMany(b=>b.Posts);
            modelBuilder.Entity<Car>().HasMany(c=>c.SaleHistory).WithOne(s => s.Car).HasForeignKey(s => s.CarLicensePlate).HasPrincipalKey(c => c.LicensePlate);
            modelBuilder.Entity<RecordOfSale>().HasOne(s => s.Car).WithMany(c => c.SaleHistory).HasForeignKey(s => s.CarLicensePlate).HasPrincipalKey(c => c.LicensePlate);
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
        //public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
    public class Car
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public List<RecordOfSale> SaleHistory { get; set; }

    }
    public class RecordOfSale
    {
        public int id { get; set; }
        public DateTime DateSold { get; set; }
        public decimal Price { get; set; }
        public string CarLicensePlate { get; set; }
        public Car Car { get; set; } 

    }
}