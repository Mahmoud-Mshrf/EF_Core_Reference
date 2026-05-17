using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SelectOneItem.Models;

namespace SelectOneItem.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Stock> Stocks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS;Initial Catalog=Ef_Dataaa; Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stock>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stock");

            entity.Property(e => e.Balance)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Industry)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sector)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Symbol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<Stock>().HasKey(s=>s.Id);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
