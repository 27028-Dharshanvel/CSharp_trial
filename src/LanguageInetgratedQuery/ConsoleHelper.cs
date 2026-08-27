using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using LanguageInetgratedQuery.Models;

namespace LanguageInetgratedQuery
{
    /// <summary>
    /// Console Helper
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// DisplayTable
        /// </summary>
        /// <param name="products">products</param>
        public static void DisplayTable(List<Product> products)
        {
            ConsoleTable table = new ConsoleTable("ProductId", "ProductName", "ProductCategory", "ProductPrice");
            foreach (Product product in products)
            {
                table.AddRow(product.ProductId, product.ProductName, product.ProductCategory, product.ProductPrice);
            }

            table.Write();
        }
    }
}
