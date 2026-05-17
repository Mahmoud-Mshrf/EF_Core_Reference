using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexes
{
    internal class Instructions
    {
        /* How to make Index on a specific column in a table:
         * Using DataAnnotaion Putting an attribute above the class : [Index(nameof(ColumnName))]
         * Using FluentAPI : modelBuilder.Entity<Blog>.HasIndex(b=>b.ColumnName)
         * 
         * How to make Unique Index on a specific column in a table:
         * Using DataAnnotaion Putting an attribute above the class : [Index(nameof(ColumnName)),IsUnique=True)]
         * Using FluentAPI : modelBuilder.Entity<Blog>.HasIndex(b=>b.ColumnName).IsUnique();
         * 
         * How to make Composite Index on a specific column in a table:
         * Using DataAnnotaion Putting an attribute above the class : [Index(nameof(ColumnName),nameof(OtherColumnName))]
         * Using FluentAPI : modelBuilder.Entity<Blog>.HasIndex(b=> new {b.ColumnName,b.OtherColumnName});
         * 
         * How to give name for Index on a specific column in a table:
         * Using DataAnnotaion Putting an attribute above the class : [Index(nameof(ColumnName),Name="theName")]
         * Using FluentAPI : modelBuilder.Entity<Blog>.HasIndex(b=>b.ColumnName).HasDatabaseName("theName");
         * 
         * How to make filter on index :
         * Using FluentAPI : Ex: modelBuilder.Entity<Blog>.HasIndex(b=>b.ColumnName).HasFilter("[Url] IS NOT NULL");
         * Using FluentAPI : Ex: modelBuilder.Entity<Blog>.HasIndex(b=>b.ColumnName).IsUnique().HasFilter(null);
         * 
         * note: when you make an unique index on a column by default this column be required 
         * to make the unique index not required we can do this:
         * Using FluentAPI : Ex: modelBuilder.Entity<Blog>.HasIndex(b=>b.ColumnName).IsUnique().HasFilter(null);
         * 
         */
    }
}
