using LanguageInetgratedQuery.Models;

namespace LanguageInetgratedQuery
{
    /// <summary>
    /// Linq Tasks to be demonstrated.
    /// </summary>
    internal class LinqTask
    {
        /// <summary>
        /// Basic Linq Tasks such as filtering.
        /// </summary>
        /// <param name="products">products</param>
        public static void ExecuteBasicLinqTask(List<Product> products)
        {
            Console.WriteLine();
            Console.WriteLine("TASK 1 - BASIC LINQ QUERIES");
            Console.WriteLine();

            ConsoleHelper.DisplayTable(
                products,
                new[] { "ProductId", "ProductName", "ProductCategory", "ProductPrice" },
                p => new object[] { p.ProductId, p.ProductName, p.ProductCategory, p.ProductPrice }
            );

            var products1 = products
                .Where(p => p.ProductCategory == "Electronics" && p.ProductPrice > 500)
                .Select(p => new
                {
                    p.ProductName,
                    p.ProductPrice,
                })
                .ToList();

            ConsoleHelper.DisplayTable(
                products1,
                new[] { "ProductName", "ProductPrice" },
                p => new object[] { p.ProductName, p.ProductPrice }
            );

            var products2 = products1
                .OrderByDescending(p => p.ProductPrice)
                .ToList();

            ConsoleHelper.DisplayTable(
                products2,
                new[] { "ProductName", "ProductPrice" },
                p => new object[] { p.ProductName, p.ProductPrice }
            );

            decimal average = products1.Average(p => p.ProductPrice);

            Console.WriteLine();
            Console.WriteLine("Average Price: " + average);
        }

        /// <summary>
        /// Intermediate Linq Tasks such as joining.
        /// </summary>
        /// <param name="products">products</param>
        /// <param name="suppliers">suppliers</param>
        public static void ExecuteIntermediateLinqTask(
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
                        .First(),
                })
                .ToList();

            ConsoleHelper.DisplayTable(
                products3,
                new[] { "Category", "ProductCount", "MostExpensiveProduct", "Price" },
                c => new object[] { c.Category, c.ProductCount, c.MostExpensiveProduct.ProductName, c.MostExpensiveProduct.ProductPrice }
            );

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
                        supplier.SupplierName,
                    })
                .ToList();

            ConsoleHelper.DisplayTable(
                productSuppliers,
                new[] { "ProductId", "ProductName", "ProductCategory", "ProductPrice", "SupplierName" },
                ps => new object[] { ps.ProductId, ps.ProductName, ps.ProductCategory, ps.ProductPrice, ps.SupplierName }
            );
        }

        /// <summary>
        /// Advanced Linq tasks involving multiple linq methods.
        /// </summary>
        /// <param name="numbers">numbers</param>
        public static void ExecuteAdvancedLinqTask(int[] numbers)
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
                            SecondNumber = secondNumber,
                        }))
                .ToList();

            ConsoleHelper.DisplayTable(
                pairs,
                new[] { "FirstNumber", "SecondNumber" },
                pair => new object[] { pair.FirstNumber, pair.SecondNumber }
            );
        }

        /// <summary>
        /// Optimized Linq queries for better performance.
        /// </summary>
        /// <param name="products">products</param>
        public static void ExecuteOptimizedLinqTask(List<Product> products)
        {
            Console.WriteLine();
            Console.WriteLine("TASK 4 - PERFORMANCE CONSIDERATIONS WITH LINQ");
            Console.WriteLine();

            var books = products
                .Where(p => p.ProductCategory == "Books")
                .OrderBy(p => p.ProductPrice)
                .ToList();

            ConsoleHelper.DisplayTable(
                books,
                new[] { "ProductId", "ProductName", "ProductCategory", "ProductPrice" },
                p => new object[] { p.ProductId, p.ProductName, p.ProductCategory, p.ProductPrice }
            );

            var optimizedBooks = products
                .Where(p => p.ProductCategory == "Books")
                .OrderBy(p => p.ProductPrice)
                .Select(p => new
                {
                    p.ProductName,
                    p.ProductPrice,
                })
                .ToList();

            ConsoleHelper.DisplayTable(
                optimizedBooks,
                new[] { "ProductName", "ProductPrice" },
                p => new object[] { p.ProductName, p.ProductPrice }
            );
        }

        /// <summary>
        /// Implementation of Fluent api pattern via QueryBuilder.
        /// </summary>
        /// <param name="products">products</param>
        public static void ExecuteFluentApiPattern(List<Product> products)
        {
            Console.WriteLine("Querybuilder");
            var queryBuilder = new QueryBuilder<Product>(products);

            var result = queryBuilder.Filter(p => p.ProductPrice > 500).SortBy(p => p.ProductName).Execute();

            ConsoleHelper.DisplayTable(
                result,
                new[] { "ProductId", "ProductName", "ProductCategory", "ProductPrice" },
                p => new object[] { p.ProductId, p.ProductName, p.ProductCategory, p.ProductPrice }
            );
        }
    }
}
