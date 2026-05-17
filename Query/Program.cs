using Query.Data;
using Query.Models;
using System.Reflection.Metadata;

namespace Query
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                
            }
        }

        private static void GroupBy(AppDbContext context)
        {
            var Industries = context.Stocks.GroupBy(x => x.Industry)
                .Select(x => new { InsudtryName = x.Key, IndustryCount = x.Count() })
                .OrderByDescending(x => x.IndustryCount);
            foreach (var item in Industries)
            {
                Console.WriteLine($"{item.InsudtryName}    {item.IndustryCount}");
            }
        }

        private static List<Stock> Pagination(AppDbContext context,int PageNumber ,int pageSize)
        {
            return context.Stocks.Skip((PageNumber-1)* pageSize).Take(pageSize).ToList();
        }

        private static void distinct( AppDbContext context)
        {
            var DistinctStocks = context.Stocks.Distinct();// doesn't make any changes because the primarykey is unique so we must select the other fields
            var DistinctStocksNames = context.Stocks.Select(x => new { x.Name }).Distinct();// it will return the distinct values only
            foreach (var item in DistinctStocksNames)
            {
                Console.WriteLine($"{item.Name}");
            }   
        }

        private static void Select_Projection(AppDbContext context)
        {
            var stocksName_Id = context.Stocks.Select(x => new { x.Id, x.Name });
            var stocksName_Id_ToBlog = context.Stocks.Select(x => new Blog { BlogId = x.Id, URL = x.Name });// change the result data from type to another type
            foreach (var item in stocksName_Id)
            {
                Console.WriteLine($"{item.Id}  {item.Name}");
            }
            
        }

        private static void OrderBy_ThenBy(AppDbContext context)
        {
            var OrderedStocks = context.Stocks.OrderBy(x => x.Name);
            var DescendingOrderedStocks = context.Stocks.OrderByDescending(x => x.Name);
            var OrderedStockss = context.Stocks.OrderBy(x => x.Name).ThenBy(x => x.Balance);
            var DescendingOrderedStockss = context.Stocks.OrderByDescending(x => x.Name).ThenBy(x => x.Balance);
            foreach (var order in OrderedStockss)
            {
                Console.WriteLine($"{order.Name}    {order.Balance}");

            }
            foreach (var order in DescendingOrderedStockss)
            {
                Console.WriteLine($"{order.Name}    {order.Balance}");
            }

        }

        private static void Max_Min(AppDbContext context)
        {

            var MinStockName = context.Stocks.Min(s => s.Name);
            var MaxStock = context.Stocks.Max(s => s.Id);
            var MaxStockName = context.Stocks.Max(s => s.Name);
            var MinStock = context.Stocks.Min(s => s.Id);

        }

        private static void Avg_Count_Sum(AppDbContext context)
        {
            var stocksBalanceAVG = context.Stocks.Average(s => s.Id);
            var stocksCount = context.Stocks.Count();
            var stockCount = context.Stocks.Count(s => s.Id > 500);
            var stocksSum = context.Stocks.Sum(s => s.Id);
        }

        private static void Append_Prepend(AppDbContext context)
        {
            context.Stocks.ToList().Append(new Stock { Id = 1001, Name = "Test " });// Add item at the end of the list
            var stocks = context.Stocks.ToList().Prepend(new Stock { Id = 1002, Name = "Test 2 " });// Add item at the start of the list

            foreach (var item in stocks)
            {
                Console.WriteLine(item.Id);
            }

        }

        private static void All_Any(AppDbContext context)
        {
            var IfStocks = context.Stocks.Any(s => s.Id > 500);//True
            var IfStockss = context.Stocks.Any();// True
            var IfAllStocks = context.Stocks.All(s => s.Id > 500);//False

        }

        private static void Where(AppDbContext context)
        {

            var StocksAbove500 = context.Stocks.Where(s => s.Id > 500);
            foreach (var stock in StocksAbove500)
            {
                Console.WriteLine(stock.Id);
            }
        }
    }
}