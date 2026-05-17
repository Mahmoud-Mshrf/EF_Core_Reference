using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReverseEngineering.Configurations;

namespace ReverseEngineering.Models;

public partial class EfToturialTestContext : DbContext
{
    public EfToturialTestContext()
    {
    }

    public EfToturialTestContext(DbContextOptions<EfToturialTestContext> options): base(options)
    {
    }

    public virtual DbSet<Authorss> Authorsses { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Nationality> Nationalities { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF_ToturialTest;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Authorss>(entity =>
        {
            entity.ToTable("Authorss");

            entity.HasIndex(e => e.NationalityId, "IX_Authorss_NationalityId");

            entity.HasOne(d => d.Nationality).WithMany(p => p.Authorsses).HasForeignKey(d => d.NationalityId);
        });

        new BookEntityTypeConfiguration().Configure(modelBuilder.Entity<Book>());

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasIndex(e => e.BlogId, "IX_Posts_BlogId");

            entity.HasOne(d => d.Blog).WithMany(p => p.Posts).HasForeignKey(d => d.BlogId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
