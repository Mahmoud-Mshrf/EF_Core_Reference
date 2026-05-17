using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOneRelationShip
{
    internal class Instructions
    {
        /*
         * To make a One-To-One Relationship Between Two Tables:
         * we put an object from each class in the other class as a navigation property This mean that each object from one class contains object from the other class
         * and in one class from the two classes we but an id as a ForeignKey 
         * Example :
         * public class Blog
         * {
         *     public int Id { get; set; }
         *     public string Url { get; set; }
         *     public BlogImage blogImage { get; set; }
         * }
         * public class BlogImage
         * {
         *     public int Id { get; set; }
         *     public string Caption { get; set; }
         *     public int BlogId { get; set; }
         *     public Blog blog { get; set; }
         * }
         * in the above example the entityFrameWork by itself discover that the Property BlogId it represents the ForeignKey because its name
         * but if its name was different it may doesn't discover it So to we must Explicitly declare it as a ForeignKey 
         * For Example :
         * public class Blog
         * {
         *     public int Id { get; set; }
         *     public string Url { get; set; }
         *     public BlogImage blogImage { get; set; }
         * }
         * public class BlogImage
         * {
         *     public int Id { get; set; }
         *     public string Caption { get; set; }
         *     public int BlogForeignKey { get; set; }
         *     public Blog blog { get; set; }
         * }
         * Using (FluentAPI): modelBuilder.Entity<Blog>()
         *                        .HasOne(b=>b.blogImage)
         *                        .WithOne(i=>i.blog)
         *                        .HasForeignKey<BlogImage>(i=>i.BlogForeignKey)
         * 
         */
    }
}
