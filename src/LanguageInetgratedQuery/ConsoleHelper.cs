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
            ConsoleTable table = new ConsoleTable(
                "ProductId",
                "ProductName",
                "ProductCategory",
                "ProductPrice");

            foreach (Product product in products)
            {
                table.AddRow(
                    product.ProductId,
                    product.ProductName,
                    product.ProductCategory,
                    product.ProductPrice);
            }

            table.Write();
        }

        /// <summary>
        /// Display Product Price Table
        /// </summary>
        /// <param name="products">products</param>
        public static void DisplayProductPriceTable<T>(List<T> products)
        {
            ConsoleTable table = new ConsoleTable(
                "ProductName",
                "ProductPrice");

            foreach (dynamic product in products)
            {
                table.AddRow(
                    product.ProductName,
                    product.ProductPrice);
            }

            table.Write();
        }

        /// <summary>
        /// Display Category Table
        /// </summary>
        /// <param name="products">products</param>
        public static void DisplayCategoryTable<T>(List<T> products)
        {
            ConsoleTable table = new ConsoleTable(
                "Category",
                "ProductCount",
                "MostExpensiveProduct",
                "Price");

            foreach (dynamic product in products)
            {
                table.AddRow(
                    product.Category,
                    product.ProductCount,
                    product.MostExpensiveProduct.ProductName,
                    product.MostExpensiveProduct.ProductPrice);
            }

            table.Write();
        }

        /// <summary>
        /// Display Supplier Table
        /// </summary>
        /// <param name="products">products</param>
        public static void DisplaySupplierTable<T>(List<T> products)
        {
            ConsoleTable table = new ConsoleTable(
                "ProductId",
                "ProductName",
                "ProductCategory",
                "ProductPrice",
                "SupplierName");

            foreach (dynamic product in products)
            {
                table.AddRow(
                    product.ProductId,
                    product.ProductName,
                    product.ProductCategory,
                    product.ProductPrice,
                    product.SupplierName);
            }

            table.Write();
        }

        /// <summary>
        /// Display Pairs Table
        /// </summary>
        /// <param name="pairs">pairs</param>
        public static void DisplayPairsTable<T>(List<T> pairs)
        {
            ConsoleTable table = new ConsoleTable(
                "FirstNumber",
                "SecondNumber");

            foreach (dynamic pair in pairs)
            {
                table.AddRow(
                    pair.FirstNumber,
                    pair.SecondNumber);
            }

            table.Write();
        }
    }
}