using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Models;
using ConsoleTables;

namespace Assignment3.View
{
    /// <summary>
    /// To present data in table format.
    /// </summary>
    internal static class DisplayTable
    {
        /// <summary>
        /// To Display product details in table.
        /// </summary>
        /// <param name="products">products</param>
        public static void DisplayProductTable(List<Product> products)
        {
            var table = new ConsoleTable("ProductID", "ProductName", "Price", "Quantity");
            foreach (Product product in products)
            {
                table.AddRow(product.ProductId, product.Name, product.Price, product.Quantity);
            }

            table.Write();
        }

    }
}
