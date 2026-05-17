using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InculdeDomainModel
{
    internal class Instructions3
    {
        /*
         * How to Inculde a Model(class) in the EntityFramework Model:
         * Using DbSet<> on the DbContext 
         * Using Navigation Property this is an implicitly way this mean that a class have objects from other class as a property on it
         * Using (FluentApi): OnModelCreating function       EX:  modelBuiler.Entity<AuditEntry>();
         * 
         * How to Exclude a Model(class) from the EntityFramework Model:
         * Using Data Annotation By Putting an Attribute [NotMapped] on the class
         * Using (FluentApi): OnModelCreating function       EX:  modelBuiler.Ignore<AuditEntry>();
         * If we make a model that we don't wanna make it affected by new migrations we can do this by:
         * Using (FluentApi): modelBuiler.Entity<AuditEntry>().ToTable("AuditEntry",a=>a.ExcludefromMigrations());
         * 
         * How to map a model to a table with a different name in the database:
         * Using Data Annotation By Putting an Attribute [Table("TableName")] on the class
         * Using (FluentApi): OnModelCreating function       EX:  modelBuiler.Entity<AuditEntry>().ToTable("TableName");
         * 
         * How to map a model to a table with a different name and To a different Schema in the database:
         * Using Data Annotation By Putting an Attribute [Table("TableName", schema ="SchemaName")] on the class
         * Using (FluentApi): OnModelCreating function       EX:  modelBuilder.Entity<AuditEntry>().ToTable("TableName",schema: "SchemaName");
         * 
         * How to include a view that its return view represent a domain model the entityframework model
         * Using (FluentApi): OnModelCreating function       EX:  modelBuilder.Entity<AuditEntry>().ToView("TableName",schema: "SchemaName");
         * 
         * How to make a new schema and make it the deafult schema in the entityFrameWork Model:
         * Using (FluentApi): OnModelCreating function       EX: modelBuilder.HasDeafultSchema("SchemaName");
         * 
         * How to Exclude a property from domain model to be not mapped to database:
         * Using Data Annotation By Putting an Attribute [NotMapped] on the property
         * Using (FluentApi): OnModelCreating function       EX:  modelBuilder.Entity<AuditEntry>().Ignore(a=>a.PropertyName);
         * 
         * How to change name of column in a specified table in DB:
         * Using Data Annotation By Putting an Attribute [Column("NewName")] on the property
         * Using (FluentApi): OnModelCreating function       EX:  modelBuilder.Entity<AuditEntry>().Property(a=>a.PropertyName).HasCoulmnName("NewName");
         * 
         * How to change the datatype of a column in db
         * Using Data Annotation By Putting an Attribute [Column(TypeName:="varchar(200)")] on the property
         * Using (FluentApi): OnModelCreating function       EX:  modelBuilder.Entity<AuditEntry>().Property(a=>a.PropertyName).HasCoulmnType("varchar(100)");
         * 
         * How to put a maximum length to a string column in db:
         * Using Data Annotation By Putting an Attribute [MaxLength(200)] on the property
         * Using (FluentApi): OnModelCreating function       EX:  modelBuilder.Entity<AuditEntry>().Property(a=>a.PropertyName).HasMaxLength(200);
         * 
         * How to add a comment to a specified column in db:
         * Using Data Annotation By Putting an Attribute [Comment("This is a comment")] on the property
         * Using (FluentApi): OnModelCreating function       EX:  modelBuilder.Entity<AuditEntry>().Property(a=>a.PropertyName).HasComment("This is a comment");
         * 
         * How to add Primary key column to a table in db:
         * by deafult if there are a property in the class have the following convention it considered as primary key :
         * PrimaryKey Convention (Id, id ,ID) Or (ClassId,ClassID,Classid)
         * if the class doesn't contain any property with this convention then we must declare a property as a primary key:
         * Using Data Annotation By Putting an Attribute [Key] on the property 
         * Using (FluentApi): OnModelCreating function       EX:  modelBuilder.Entity<AuditEntry>().HasKey(a=>a.PrimaryKeyPrpertyName)
         * 
         * By Deafult the primary key stored in db with deafult names but we can give it a specified name:
         * Using (FluentApi): OnModelCreating function       EX:  modelBuilder.Entity<AuditEntry>().HasKey(a=>a.PrimaryKeyPrpertyName).HasName("NewName")
         * 
         * How to set composite key to a table in db :
         * Using (FluentApi): OnModelCreating function       EX:  modelBuilder.Entity<AuditEntry>().HasKey(a=> new {a.Name , a.author})
         * 
         * How to Set Deafult value to a column in db:
         * modelBuilder.Entity<Blog>().Property(b=>b.Url).HasDeafaultValue("localhost:8080");
         * if i want to assign the deafult value by appling sql statement: modelBuilder.Entity<Blog>().Property(b=>b.CreatedAt).HasDeafaultValueSql("GETDATE()");
         * 
         * How to add a computed Column in a db 
         * first we add a property in the class that represent this column
         * then to make this property be the result of a computed or combined result from other properties:
         * Using (FluentApi): OnModelCreating function   EX: modelBuilder.Entity<UserName>().Property(u=>u.FullName).HasComputedColumnSql("[FirstName] +' '+ [LastName]")
         * 
         * 
         * If we make the id of type not int for example: byte
         * so it will be the primary key for this table but it will not be identity 
         * we must declare this as identity explicitly :
         * Using Data Annotation By Putting an Attribute [DatabaseGenerated(DatabaseGeneratedOption.Identity)] on the id property 
         * Using (FluentApi): OnModelCreating function       EX: modelBuilder.Entity<Blog>().Property(b=>b.id).ValueGeneratedOnAdd(); 
         * 
         */ 
    }
}
