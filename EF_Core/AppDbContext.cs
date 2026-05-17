using EF_Core7_1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //var configration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //var connectionString = configration.GetSection("constr").Value;
            //optionsBuilder.UseSqlServer(connectionString);
            // The Above Do the same Like The next Line:
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF_Testt;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            
        }
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
    // To make a property required we can make it by several ways:
    // Data Annotation 
}
