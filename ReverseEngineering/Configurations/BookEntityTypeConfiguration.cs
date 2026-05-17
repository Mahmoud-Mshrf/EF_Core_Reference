using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReverseEngineering.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseEngineering.Configurations
{
    internal class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasIndex(e => e.AuthorId, "IX_Books_AuthorId");

            builder.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Author).WithMany(p => p.Books).HasForeignKey(d => d.AuthorId);
        }
    }
}
