using EF_Core8.Configurations;
using EF_Core8.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core8
{
    public class AppDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server =DESKTOP-R7LIJV7\\SQLEXPRESS ; Database =EF_Blogs ; Integrated Security =SSPI ; TrustServerCertificate =True ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Blog>().Property(u=>u.URL).IsRequired();
            //new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);
        }
    }
}