using System;
using System.Collections.Generic;
using Database_Scaffolding.Models;
using Microsoft.EntityFrameworkCore;

namespace Database_Scaffolding.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WishList> WishLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS;Initial Catalog=AMZ_Database; Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__43AA41416AC5CF4C");

            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__2EF52A270A9189A2");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__user_id__4222D4EF");

            entity.HasMany(d => d.Products).WithMany(p => p.Carts)
                .UsingEntity<Dictionary<string, object>>(
                    "CartProduct",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Cart_Prod__Produ__5070F446"),
                    l => l.HasOne<Cart>().WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Cart_Prod__cart___4F7CD00D"),
                    j =>
                    {
                        j.HasKey("CartId", "ProductId").HasName("PK__Cart_Pro__177615DE9B699A1B");
                        j.ToTable("Cart_Product");
                        j.IndexerProperty<int>("CartId").HasColumnName("cart_id");
                        j.IndexerProperty<int>("ProductId").HasColumnName("Product_id");
                    });
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__D54EE9B4852CD440");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Products).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryProduct",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Category___Produ__5441852A"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Category___categ__534D60F1"),
                    j =>
                    {
                        j.HasKey("CategoryId", "ProductId").HasName("PK__Category__ECCDD64DCEB130DC");
                        j.ToTable("Category_Product");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                        j.IndexerProperty<int>("ProductId").HasColumnName("Product_id");
                    });
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__9833FF926005B9DD");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("Product_id");
            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.Admin).WithMany(p => p.Products)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__admin_i__3D5E1FD2");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.SellerId).HasName("PK__Seller__7FE3DBA1B0BD5F77");

            entity.ToTable("Seller");

            entity.Property(e => e.SellerId).HasColumnName("SellerID");
            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Admin).WithMany(p => p.Sellers)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Seller__admin_id__3A81B327");

            entity.HasMany(d => d.Products).WithMany(p => p.Sellers)
                .UsingEntity<Dictionary<string, object>>(
                    "SellerProduct",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Seller_Pr__Produ__48CFD27E"),
                    l => l.HasOne<Seller>().WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Seller_Pr__Selle__47DBAE45"),
                    j =>
                    {
                        j.HasKey("SellerId", "ProductId").HasName("PK__Seller_P__4660E4587A0163A7");
                        j.ToTable("Seller_Product");
                        j.IndexerProperty<int>("SellerId").HasColumnName("SellerID");
                        j.IndexerProperty<int>("ProductId").HasColumnName("Product_id");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__B9BE370F98843379");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.HasKey(e => e.WishId).HasName("PK__Wish_lis__4F227CA00337DCF3");

            entity.ToTable("Wish_list");

            entity.Property(e => e.WishId).HasColumnName("wish_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Wish_list__user___44FF419A");

            entity.HasMany(d => d.Products).WithMany(p => p.Wishes)
                .UsingEntity<Dictionary<string, object>>(
                    "WishProduct",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Wish_Prod__Produ__4CA06362"),
                    l => l.HasOne<WishList>().WithMany()
                        .HasForeignKey("WishId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Wish_Prod__wish___4BAC3F29"),
                    j =>
                    {
                        j.HasKey("WishId", "ProductId").HasName("PK__Wish_Pro__76A143596BAED1BD");
                        j.ToTable("Wish_Product");
                        j.IndexerProperty<int>("WishId").HasColumnName("wish_id");
                        j.IndexerProperty<int>("ProductId").HasColumnName("Product_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
