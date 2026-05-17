using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core8
{
    internal class Istruction2
    {
        /*
         * to make a property required we can use :
         * data annotation by adding an [required] attribute above the property
         * OR
         * by(FluentAPI): override onmodelCreating method and decare this property as required Example:
         * protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Blog>().Property(u=>u.URL).IsRequired();
            }
         * 
         * 
         * we can seperate the Domain_Model for each model in a seperated file: 
         * by make a class to each model that represent the configuration to this class 
         * Example:
         * if i want to make a configuration to the Blog class:
         * public class BlogEntityTypeConfiguration:IEntityTypeConfiguration<Blog>
         * {
         *      public void Configure(EntityTypeBuilder<Blog> builder)=>
         *          buider.Property(b=>b.url).IsRequired();
         * }
         * the two following lines to invoke it in OnModelCreating Function:
         * new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
         * modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);
         */
    }
}
