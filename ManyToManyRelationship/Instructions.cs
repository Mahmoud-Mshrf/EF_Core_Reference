using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyRelationship
{
    internal class Instructions
    {
        /* if we wanna make a relation ManyToMany between two tables, we need to make a link or intermidiate table:
         * The SimplistWay Using Collection Navigation Properties and the EF_Core will create the intermediate table, Example:
         * public class Post
         * {
         *     public int Id { get; set; }
         *     public string Title { get; set; }
         *     public string Content { get; set; }
         *     public ICollection<Tag> Tags { get; set; }
         * }
         * public class Tag
         * {
         *     public string Id { get; set; }
         *     public ICollection<Post> Posts { get; set;}
         * }
         * 
         * we can do this by FluentAPI:
         * modelBuilder.Entity<Post>().HasMany(p=>p.Tags).WithMany(t=>t.Posts).UsingEntity(j=>j.ToTable("PostTagTable")); 
         * 
         * we can make the intermidate class by ourself :
         * public class Post
         * {
         *     public int PostId { get; set; }
         *     public string Title { get; set; }
         *     public string Content { get; set; }
         *     public ICollection<Tag> Tags { get; set; }
         *     public List<PostTag> PostTags { get; set; }
         * }
         * public class Tag
         * {
         *     public string TagId { get; set; }
         *     public ICollection<Post> Posts { get; set;}
         *     public List<PostTag> PostTags { get; set; }
         * 
         * }
         * public class PostTag
         * {
         *     public int PostId { get; set; }
         *     public string TagId { get; set; }
         * 
         *     public Post Post { get; set; }
         *     public Tag Tag { get; set; }
         * }
         * after making the above we use FluentAPI :
         * modelBuilder.Entity<Post>()
         *     .HasMany(p => p.Tags)
         *     .WithMany(t => t.Posts)
         *     .UsingEntity<PostTag>(
         *        j=>j
         *           .HasOne(pt => pt.Tag)
         *           .WithMany(t => t.PostTags)
         *           .HasForeignKey(pt => pt.TagId),
         *        j => j
         *           .HasOne(pt => pt.Post)
         *           .WithMany(p => p.PostTags)
         *           .HasForeignKey(pt => pt.PostId),
         *        j =>j
         *           .HasKey(pt => new { pt.PostId, pt.TagId })
         *           );
         * 
         * we can decompose the above code and make indirect manyToManyRelationship
         * but first in the classes we remove the IcollectionProperties :
         * public class Post
         * {
         *     public int PostId { get; set; }
         *     public string Title { get; set; }
         *     public string Content { get; set; }
         *     public List<PostTag> PostTags { get; set; }
         * }
         * public class Tag
         * {
         *     public string TagId { get; set; }
         *     public List<PostTag> PostTags { get; set; }
         * 
         * }
         * public class PostTag
         * {
         *     public int PostId { get; set; }
         *     public string TagId { get; set; }
         * 
         *     public Post Post { get; set; }
         *     public Tag Tag { get; set; }
         * }
         * Using FluentAPI:
         * modelBuilder.Entity<PostTag>().HasKey(pt => new { pt.PostId, pt.TagId });
         * modelBuilder.Entity<PostTag>().HasOne(pt => pt.Tag)
         *                               .WithMany(t => t.PostTags)
         *                               .HasForeignKey(pt => pt.TagId);
         * modelBuilder.Entity<PostTag>().HasOne(pt => pt.Post)
         *                               .WithMany(t => t.PostTags)
         *                               .HasForeignKey(pt => pt.PostId);
         * 
         * 
         * this will do the same as the previous code
         * 
         */
    }
}
