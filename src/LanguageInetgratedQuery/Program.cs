using ConsoleTables;
using LanguageInetgratedQuery.Models;
using LanguageInetgratedQuery.Repository;

namespace Assignments
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        private Repository _repo = new Repository();

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">cmd args</param>
        public static void Main(string[] args)
        {
            Repository repo = new Repository();
            List<Product> products = repo.GetProducts();
            ConsoleTable table = new ConsoleTable("ProductId", "ProductName", "ProductCategory", "ProductPrice");
            ConsoleTable table1 = new ConsoleTable("ProductName", "ProductPrice");
            ConsoleTable table2 = new ConsoleTable("ProductName", "ProductPrice");
            ConsoleTable table3 = new ConsoleTable("ProuctId","ProductName", "ProductCategory", "ProductPrice");
            foreach (Product product in products)
            {
                table.AddRow(product.ProductId, product.ProductName, product.ProductCategory, product.ProductPrice);
            }

            table.Write();
            var products1 = products.Where(p => p.ProductCategory == "Electronics" && p.ProductPrice > 500).Select(p => new
            {
                p.ProductName,
                p.ProductPrice,
            }).ToList();

            foreach (var product in products1)
            {
                table1.AddRow(product.ProductName, product.ProductPrice);
            }

            table1.Write();

            var products2 = products1.OrderByDescending(p => p.ProductPrice).ToList();
            foreach (var product in products2)
            {
                table2.AddRow(product.ProductName, product.ProductPrice);
            }

            table2.Write();

            decimal average = products1.Average(p => p.ProductPrice);
            Console.WriteLine(average);

            /////////////////////////////////////////////////////////////////
            var products3 = products.GroupBy(p => p.ProductCategory).ToList();

            foreach (var group in products3)
            {
                foreach (var product in group)
                {
                    table3.AddRow(
                        product.ProductPrice,
                        product.ProductName,
                        product.ProductPrice,
                        group.Key);
                }
            }

            table3.Write();
        }
    }
}