using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Loading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EagerLoading();
            //ExplicitLoading();
            ExplicitLoading2();
            //ExplicitLoading3();
            //LazyLoading();
            SplitQueries();
        }

        private static void SplitQueries()
        {
            using (var context = new AppDbContext())
            {
                // Default Behaviour of EFCore is SingleQuery The following Statement Will Make in one query
                var book = context.Books.Include(b => b.Author).ThenInclude(a => a.Nationality).SingleOrDefault(b => b.Id == 2);
                Console.WriteLine(book.Author.Nationality.Name);
                // We Can Split it into several Queries:
                var book2 = context.Books.Include(b => b.Author).ThenInclude(a => a.Nationality).AsSplitQuery().SingleOrDefault(b => b.Id == 2);



                // We Can Make SplitQuery the default to the Context By Declare it in OnConfiguring Method in DbContext Class:
                // EX:
                //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                //{
                //    base.OnConfiguring(optionsBuilder);
                //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS;Initial Catalog= Ef_Books ;Integrated Security=True;TrustServerCertificate=True;", o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
                //
                //}
                //
            }

        }

        private static void LazyLoading()
        {
            // The problem with eager loading that it load the related entity once select the main entity from the context 
            // but Lazy Loading Not  load the related data until we access it 
            // to Use Lazy Loading we Need to Download Microsoft.EntityFrameworkCore.Proxies Package 
            // in the AppDbContext Class in OnConfiguring Method before Use SqlServer We UseLazyLoading
            // and make all the navigation Properties Virtual 
            // EX:
            // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //{
            //    base.OnConfiguring(optionsBuilder);
            //    optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=DESKTOP-R7LIJV7\\SQLEXPRESS;Initial Catalog= Ef_Books ;Integrated Security=True;TrustServerCertificate=True;");
            //}

            using (var context = new AppDbContext())
            {
                var book = context.Books.SingleOrDefault(b => b.Id == 2);
                Console.WriteLine(book.Author.Nationality.Name);
            }
        }

        private static void ExplicitLoading2()
        {
            using var context = new AppDbContext();
            var Author = context.Authors.FirstOrDefault(a=>a.Id==3);
            context.Entry(Author).Collection(a=>a.Books).Query().Where(b=>b.Name.StartsWith("G")).ToList();
            foreach (var item in Author.Books)
            {
                Console.WriteLine(item.Name);
            }
        }
        private static void ExplicitLoading3()
        {
            using var context = new AppDbContext();
            var Author = context.Authors.FirstOrDefault(a => a.Id == 3);
            context.Entry(Author).Collection(a => a.Books).Load();
            foreach (var item in Author.Books)
            {
                Console.WriteLine(item.Name);
            }
        }
        private static void ExplicitLoading()
        {
            // Here we can include the related entities in 2 steps after selecting the main entity 
            using var context = new AppDbContext();
            var books = context.Books.FirstOrDefault();
            context.Entry(books).Reference(b=>b.Author).Load();

            Console.WriteLine(books.Author.Name);
        }

        private static void EagerLoading()
        {
            // Eager loading is the process whereby a query for one type of entity also loads related entities as part of the query,
            // so that we don't need to execute a separate query for related entities. Eager loading is achieved using the Include() method.
            // this mean that if the class have in it a navigation property to object from another class so we can include the other class in the dbcontext, But This Expensive
            using (var context = new AppDbContext())
            {
                var book = context.Books.Include(b=>b.Author).ThenInclude(a => a.Nationality).SingleOrDefault(b=>b.Id== 2);
                Console.WriteLine(book.Author.Nationality.Name);
            }
        }
    }
}