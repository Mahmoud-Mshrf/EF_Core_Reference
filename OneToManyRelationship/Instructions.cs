using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToManyRelationship
{
    internal class Instructions
    {
        /*
         * How to make a One-To-Many Relationship:
         * The Best And SimplistWay Using Navigation Properties and ForeignKey Property, Example:
         * public class Blog
         * {
         *     public int Id { get; set; }
         *     public string Url { get; set; }
         *     public List<Post> Posts { get; set; }// Collection Navigation Property 
         * }
         * public class Post
         * {
         *     public int Id { get; set; }
         *     public string Title { get; set; }
         *     public string Content { get; set; }
         *     public int BlogId { get; set; }// ForeignKey
         *     public Blog Blog { get; set; }// Reference Navigation Property
         * }
         * The above will create the tables with Relationships without need FluentAPI
         * 
         * if we remove the foreign key property the result will still the same because the existence of the navigation properties, Example:  
         * public class Blog
         * {
         *     public int Id { get; set; }
         *     public string Url { get; set; }
         *     public List<Post> Posts { get; set; }// Collection Navigation Property 
         * }
         * public class Post
         * {
         *     public int Id { get; set; }
         *     public string Title { get; set; }
         *     public string Content { get; set; }
         *     public Blog Blog { get; set; }// Reference Navigation Property
         * }
         * 
         * if we remove the the navaigation property for the parent class from the child class
         * the result still the same but we can't navigate from the post to the blog mean that we can't acces the blog from the post 
         * Example:
         * public class Blog
         * {
         *     public int Id { get; set; }
         *     public string Url { get; set; }
         *     public List<Post> Posts { get; set; }// Collection Navigation Property 
         * }
         * public class Post
         * {
         *     public int Id { get; set; }
         *     public string Title { get; set; }
         *     public string Content { get; set; }
         * }
         * 
         * 
         * Using (FluentAPI): if the navigation properties still exists in the two classes without the existence of the foreignKey property 
         * Example:
         * public class Blog
         * {
         *     public int Id { get; set; }
         *     public string Url { get; set; }
         *     public List<Post> Posts { get; set; }// Collection Navigation Property 
         * }
         * public class Post
         * {
         *     public int Id { get; set; }
         *     public string Title { get; set; }
         *     public string Content { get; set; }
         *     public Blog blog { get; set; }// Reference Navigation Property
         * }
         * so the fluentAPI will be : 
         * modelBuilder.Entity<Blog>().HasMany(b=>b.Posts).WithOne();
         * OR
         * modelBuilder.Entity<Post>().HasOne(p=>p.blog).WithMany(b=>b.Posts);
         * 
         * 
         * 
         * if we remove the navigation properties and the foreignKey property still exist 
         * Using FluentAPI :
         * modelBuilder.Entity<Post>().HasOne<Blog>().WithMany().HasForeignKey(p=>p.BlogId)
         * modelBuilder.Entity<Blog>().HasMany<Post>().WithOne().HasForeignKey(p=>p.BlogId)
         * if we want to give the foreign key another name :
         * modelBuilder.Entity<Post>().HasOne<Blog>().WithMany().HasForeignKey(p=>p.BlogId).HasConstraintName("FK_posts_Test");
         * 
         * 
         * if you wanna make a foreign key in the dependent class depend on another property unless the primaryKey 
         * Using FluentAPI: 
         * modelBuilder.Entity<Car>().HasMany(c=>c.SaleHistory).WithOne(s=>s.Car).HasForeignKey(s=>s.CarLicensePlate).HasPrincipalKey(c=>c.LicensePlate);
         * modelBuilder.Entity<RecordOfSale>().HasOne(s => s.Car).WithMany(c => c.SaleHistory).HasForeignKey(s => s.CarLicensePlate).HasPrincipalKey(c => c.LicensePlate);
         * 
         */
    }
}
