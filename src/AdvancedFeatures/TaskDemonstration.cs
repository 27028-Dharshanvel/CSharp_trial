using AdvancedFeatures.Models;

namespace AdvancedFeatures
{
    /// <summary>
    /// Represents a book model using C# records.
    /// </summary>
    /// <param name="title">The title of the book.</param>
    /// <param name="author">The author of the book.</param>
    /// <param name="iSBN">The ISBN identifier of the book.</param>
    record Book(string title, string author, string iSBN);

    /// <summary>
    /// Demonstrates various advanced C# features including delegates, events,
    /// dynamic types, anonymous methods, LINQ expressions, records, and pattern matching.
    /// </summary>
    internal class TaskDemonstration
    {
        /// <summary>
        /// Delegate definition for comparing two <see cref="Product"/> instances for sorting.
        /// </summary>
        /// <param name="product1">The first product to compare.</param>
        /// <param name="product2">The second product to compare.</param>
        /// <returns>
        /// A signed integer indicating relative order: less than zero if product1 precedes product2,
        /// zero if equal, or greater than zero if product1 follows product2.
        /// </returns>
        public delegate int SortDelegate(Product product1, Product product2);

        /// <summary>
        /// Demonstrates how to subscribe to and trigger custom event notifications.
        /// </summary>
        public void DemonstrateNotificationEvent()
        {
            Notifier notifier = new Notifier();

            // Subscribe to the event
            notifier.OnAction += DisplayMessage;

            // Trigger the event
            notifier.PerformAction();
        }

        /// <summary>
        /// Displays a string message to the standard output console.
        /// </summary>
        /// <param name="message">The text message to print.</param>
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Demonstrates the operational differences between strong static typing with <c>var</c>
        /// and dynamic resolution with <c>dynamic</c>.
        /// </summary>
        public void DemonstrateVarAndDynamic()
        {
            var number = 10;

            Console.WriteLine("Value of var: " + number);

            // This is not allowed:
            // number = "Hello";

            Console.WriteLine("var cannot change its type.");

            // dynamic
            dynamic value = 10;

            Console.WriteLine("Value of dynamic: " + value);

            // dynamic can change its type
            value = "Hello";

            Console.WriteLine("Changed dynamic value: " + value);
        }

        /// <summary>
        /// Demonstrates sorting an array using an inline anonymous delegate method.
        /// </summary>
        public void DemonstrateAnonymousSort()
        {
            int[] numbers = { 5, 2, 8, 1, 4 };

            Array.Sort(numbers, delegate (int first, int second)
            {
                if (first < second)
                {
                    return -1;
                }
                else if (first > second)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });

            Console.WriteLine("Sorted array:");

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        /// <summary>
        /// Demonstrates LINQ filtering and projection using lambda expressions.
        /// </summary>
        public void DemonstrateLambdaExpressions()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            // Filter odd numbers
            var oddNumbers = numbers.Where(number => number % 2 != 0);

            // Square the odd numbers
            var squaredNumbers = oddNumbers.Select(number =>
            {
                return number * number;
            });

            Console.WriteLine("Square of odd numbers:");

            foreach (int number in squaredNumbers)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Demonstrates pass-by-delegate sorting strategies over a list of products.
        /// </summary>
        public void DemonstrateSortDel()
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Laptop", Category = "Electronics", Price = 75000 },
                new Product { Name = "Phone", Category = "Electronics", Price = 30000 },
                new Product { Name = "Chair", Category = "Furniture", Price = 5000 },
                new Product { Name = "Table", Category = "Furniture", Price = 10000 }
            };

            // Create delegates
            SortDelegate sortByName = SortByName;
            SortDelegate sortByCategory = SortByCategory;
            SortDelegate sortByPrice = SortByPrice;

            Console.WriteLine("Sorted by Name:");
            SortAndDisplay(products, sortByName);

            Console.WriteLine();

            Console.WriteLine("Sorted by Category:");
            SortAndDisplay(products, sortByCategory);

            Console.WriteLine();

            Console.WriteLine("Sorted by Price:");
            SortAndDisplay(products, sortByPrice);
        }

        /// <summary>
        /// Compares two products by their <see cref="Product.Name"/> property alphabetically.
        /// </summary>
        /// <param name="product1">The first product to compare.</param>
        /// <param name="product2">The second product to compare.</param>
        /// <returns>An integer indicating relative alphabetical order.</returns>
        public int SortByName(Product product1, Product product2)
        {
            return string.Compare(product1.Name, product2.Name);
        }

        /// <summary>
        /// Compares two products by their <see cref="Product.Category"/> property alphabetically.
        /// </summary>
        /// <param name="product1">The first product to compare.</param>
        /// <param name="product2">The second product to compare.</param>
        /// <returns>An integer indicating relative alphabetical order.</returns>
        public int SortByCategory(Product product1, Product product2)
        {
            return string.Compare(product1.Category, product2.Category);
        }

        /// <summary>
        /// Compares two products by their numerical <see cref="Product.Price"/>.
        /// </summary>
        /// <param name="product1">The first product to compare.</param>
        /// <param name="product2">The second product to compare.</param>
        /// <returns>An integer indicating relative price comparison.</returns>
        public int SortByPrice(Product product1, Product product2)
        {
            return product1.Price.CompareTo(product2.Price);
        }

        /// <summary>
        /// Sorts a collection of products using a custom comparison delegate and prints them to the console.
        /// </summary>
        /// <param name="products">The list of products to sort and display.</param>
        /// <param name="sortDelegate">The comparison delegate used to define sorting logic.</param>
        public void SortAndDisplay(List<Product> products, SortDelegate sortDelegate)
        {
            // Fixed Bug: Uncommented and converted custom delegate to Comparison<Product>
            products.Sort((p1, p2) => sortDelegate(p1, p2));

            foreach (Product product in products)
            {
                Console.WriteLine(
                    "Name: " + product.Name +
                    ", Category: " + product.Category +
                    ", Price: " + product.Price);
            }
        }

        /// <summary>
        /// Demonstrates record creation, value equality, non-destructive mutation via <c>with</c> expressions, and deconstruction.
        /// </summary>
        public void DemonstrateRecords()
        {
            // Create books
            Book book1 = new Book(
                "The Alchemist",
                "Paulo Coelho",
                "9780061122415");

            Book book2 = new Book(
                "Clean Code",
                "Robert Martin",
                "9780132350884");

            Console.WriteLine("Book 1:");
            Console.WriteLine(book1);

            Console.WriteLine();

            Console.WriteLine("Book 2:");
            Console.WriteLine(book2);

            Console.WriteLine();

            // Value equality
            Book book3 = new Book(
                "The Alchemist",
                "Paulo Coelho",
                "9780061122415");

            Console.WriteLine("Are book1 and book3 equal?");
            Console.WriteLine(book1 == book3);

            Console.WriteLine();

            Console.WriteLine("Records are immutable.");

            Console.WriteLine();

            // Create a new record using with
            Book newBook = book1 with
            {
                title = "The Alchemist - New Edition"
            };

            Console.WriteLine("Original Book:");
            Console.WriteLine(book1);

            Console.WriteLine();

            Console.WriteLine("New Book:");
            Console.WriteLine(newBook);

            Console.WriteLine();

            // Deconstruction
            DisplayBook(book1);
        }

        /// <summary>
        /// Deconstructs a <see cref="Book"/> record into its component fields and outputs them to the console.
        /// </summary>
        /// <param name="book">The book record to deconstruct and display.</param>
        public void DisplayBook(Book book)
        {
            var (title, author, isbn) = book;

            Console.WriteLine("Deconstructed Book:");
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("ISBN: " + isbn);
        }

        /// <summary>
        /// Demonstrates type-based pattern matching over various <see cref="Shape"/> derived instances.
        /// </summary>
        public void DemonstratePatternMatching()
        {
            List<Shape> shapes = new List<Shape>();

            Circle circle = new Circle();
            circle.Name = "Circle";
            circle.Radius = 5;

            Rectangle rectangle = new Rectangle();
            rectangle.Name = "Rectangle";
            rectangle.Length = 10;
            rectangle.Width = 5;

            Triangle triangle = new Triangle();
            triangle.Name = "Triangle";
            triangle.Base = 8;
            triangle.Height = 6;

            shapes.Add(circle);
            shapes.Add(rectangle);
            shapes.Add(triangle);

            foreach (Shape shape in shapes)
            {
                DisplayShapeDetails(shape);
                Console.WriteLine();
            }

            // Test null
            DisplayShapeDetails(null);
        }

        /// <summary>
        /// Inspects the concrete type of a given <see cref="Shape"/> using switch pattern matching
        /// and displays type-specific metadata and calculated area.
        /// </summary>
        /// <param name="shape">The shape instance to inspect, or <c>null</c>.</param>
        public void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Circle circle:
                    Console.WriteLine("Shape: Circle");
                    Console.WriteLine("Radius: " + circle.Radius);
                    Console.WriteLine("Area: " + circle.CalculateArea());
                    break;

                case Rectangle rectangle:
                    Console.WriteLine("Shape: Rectangle");
                    Console.WriteLine("Length: " + rectangle.Length);
                    Console.WriteLine("Width: " + rectangle.Width);
                    Console.WriteLine("Area: " + rectangle.CalculateArea());
                    break;

                case Triangle triangle:
                    Console.WriteLine("Shape: Triangle");
                    Console.WriteLine("Base: " + triangle.Base);
                    Console.WriteLine("Height: " + triangle.Height);
                    Console.WriteLine("Area: " + triangle.CalculateArea());
                    break;

                case null:
                    Console.WriteLine("Shape is null.");
                    break;

                default:
                    Console.WriteLine("Unknown shape.");
                    break;
            }
        }
    }
}