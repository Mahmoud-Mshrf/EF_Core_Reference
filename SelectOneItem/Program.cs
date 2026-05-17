using SelectOneItem.Data;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SelectOneItem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var stocks = context.Stocks.ToList();
                //foreach (var stockk in stocks)
                //{
                //    Console.WriteLine(stockk.Name);
                //}
                var stock200 = context.Stocks.Single(b => b.Id == 200);
                Console.WriteLine(stock200.Name);
                var stock100 = context.Stocks.Find(100);// this method take as parameter the primary key to the table and return the element that match
                Console.WriteLine(stock100.Name);

                var stock300 = context.Stocks.SingleOrDefault(b => b.Id == 300);
                Console.WriteLine(stock300.Name);

                var stock700 = context.Stocks.First(b => b.Id == 700);
                Console.WriteLine(stock700.Name);

                var stock800 = context.Stocks.FirstOrDefault(b => b.Id == 800);
                Console.WriteLine(stock800.Name);

                var stockss = context.Stocks.OrderBy(b => b.Id).ToList();
                var stock500 = stockss.Last(b => b.Id == 500);// applied to ordered data or data applied orderBy on it
                Console.WriteLine(stock500.Name);

                var stock600 = stockss.LastOrDefault(b => b.Id == 600);// applied to ordered data or data applied orderBy on it
                Console.WriteLine(stock600.Name);
            }
        }
    }
}