using LanguageInetgratedQuery;
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

            Task1(products);
            Task2(products, repo.GetSuppliers());
            Task3(repo.GetNumbers());
            Task4(products);
            Task5(products);
        }

        /// <summary>
        /// Task 1
        /// </summary>
        /// <param name="products">products</param>
        public static void Task1(List<Product> products)
        {
            Console.WriteLine();
            Console.WriteLine("TASK 1 - BASIC LINQ QUERIES");
            Console.WriteLine();

            ConsoleHelper.DisplayTable(products);

            var products1 = products
                .Where(p => p.ProductCategory == "Electronics" && p.ProductPrice > 500)
                .Select(p => new
                {
                    p.ProductName,
                    p.ProductPrice,
                })
                .ToList();

            ConsoleHelper.DisplayProductPriceTable(products1);

            var products2 = products1
                .OrderByDescending(p => p.ProductPrice)
                .ToList();

            ConsoleHelper.DisplayProductPriceTable(products2);

            decimal average = products1.Average(p => p.ProductPrice);

            Console.WriteLine();
            Console.WriteLine("Average Price: " + average);
        }

        /// <summary>
        /// Task 2
        /// </summary>
        /// <param name="products">products</param>
        /// <param name="suppliers">suppliers</param>
        public static void Task2(
            List<Product> products,
            List<Supplier> suppliers)
        {
            Console.WriteLine();
            Console.WriteLine("TASK 2 - COMPLEX LINQ QUERIES");
            Console.WriteLine();

            var products3 = products
                .GroupBy(p => p.ProductCategory)
                .Select(group => new
                {
                    Category = group.Key,
                    ProductCount = group.Count(),
                    MostExpensiveProduct = group
                        .OrderByDescending(p => p.ProductPrice)
                        .First()
                })
                .ToList();

            ConsoleHelper.DisplayCategoryTable(products3);

            var productSuppliers = products
                .Join(
                    suppliers,
                    product => product.ProductId,
                    supplier => supplier.ProductId,
                    (product, supplier) => new
                    {
                        product.ProductId,
                        product.ProductName,
                        product.ProductCategory,
                        product.ProductPrice,
                        supplier.SupplierName
                    })
                .ToList();

            ConsoleHelper.DisplaySupplierTable(productSuppliers);
        }

        /// <summary>
        /// Task 3
        /// </summary>
        /// <param name="numbers">numbers</param>
        public static void Task3(int[] numbers)
        {
            Console.WriteLine();
            Console.WriteLine("TASK 3 - LINQ TO OBJECTS");
            Console.WriteLine();

            Console.WriteLine("Numbers:");

            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            int secondHighest = numbers
                .Distinct()
                .OrderByDescending(number => number)
                .Skip(1)
                .First();

            Console.WriteLine();
            Console.WriteLine("Second Highest Number: " + secondHighest);

            int target = 10;

            var pairs = numbers
                .SelectMany(
                    (number, index) => numbers
                        .Skip(index + 1)
                        .Where(secondNumber => number + secondNumber == target)
                        .Select(secondNumber => new
                        {
                            FirstNumber = number,
                            SecondNumber = secondNumber
                        }))
                .ToList();

            ConsoleHelper.DisplayPairsTable(pairs);
        }

        /// <summary>
        /// Task 4
        /// </summary>
        /// <param name="products">products</param>
        public static void Task4(List<Product> products)
        {
            Console.WriteLine();
            Console.WriteLine("TASK 4 - PERFORMANCE CONSIDERATIONS WITH LINQ");
            Console.WriteLine();

            var books = products
                .Where(p => p.ProductCategory == "Books")
                .OrderBy(p => p.ProductPrice)
                .ToList();

            ConsoleHelper.DisplayTable(books);

            var optimizedBooks = products
                .Where(p => p.ProductCategory == "Books")
                .OrderBy(p => p.ProductPrice)
                .Select(p => new
                {
                    p.ProductName,
                    p.ProductPrice
                })
                .ToList();

            ConsoleHelper.DisplayProductPriceTable(optimizedBooks);
        }

        /// <summary>
        /// Task 5 
        /// </summary>
        /// <param name="products">products</param>
        public static void Task5(List<Product> products)
        {
            Console.WriteLine("Querybuilder");
            QueryBuilder queryBuilder = new QueryBuilder(products);

            var result = queryBuilder.Filter(p => p.ProductPrice > 500).SortBy(p => p.ProductName).Execute();
            ConsoleHelper.DisplayTable(result);
        }
    }
}