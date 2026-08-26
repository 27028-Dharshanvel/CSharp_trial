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

            foreach (Product product in products)
            {
                table.AddRow(product.ProductId, product.ProductName, product.ProductCategory, product.ProductPrice);
            }

            table.Write();
            List<Product> products1 = repo.GetProducts();
            products1.Where(p => p.ProductCategory == "Electronics").Select(p => p.ProductName).ToList();
        }
    }
}