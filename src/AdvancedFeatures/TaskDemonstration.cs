using AdvancedFeatures.Models;

namespace AdvancedFeatures
{
    record Book(string title, string author, string iSBN);

    /// <summary>
    /// TaskDemonstration class
    /// </summary>
    internal class TaskDemonstration
    {
        /// <summary>
        /// Sortsdelegate
        /// </summary>
        /// <param name="product1">prduct1</param>
        /// <param name="product2">product2</param>
        /// <returns>int</returns>
        public delegate int SortDelegate(Product product1, Product product2);

        /// <summary>
        /// Demonstrates notification delegate
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
        /// Display the message
        /// </summary>
        /// <param name="message">message </param>
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Demonstrates var and dynamic keywords
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
        /// Demonstrates sort anonymous method
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
        /// Demonstrates Lambda expressions
        /// </summary>
        public void DemonstrateLambdaExpressions()
        {
            List<int> numbers = new List<int>();

            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(6);

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
        /// Demonstrates sort delegate
        /// </summary>
        public void DemonstrateSortDel()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product
            {
                Name = "Laptop",
                Category = "Electronics",
                Price = 75000
            });

            products.Add(new Product
            {
                Name = "Phone",
                Category = "Electronics",
                Price = 30000
            });

            products.Add(new Product
            {
                Name = "Chair",
                Category = "Furniture",
                Price = 5000
            });

            products.Add(new Product
            {
                Name = "Table",
                Category = "Furniture",
                Price = 10000
            });

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
        /// Sorts by name
        /// </summary>
        /// <param name="product1">first product</param>
        /// <param name="product2">second product</param>
        /// <returns>int</returns>
        public int SortByName(Product product1, Product product2)
        {
            return string.Compare(product1.Name, product2.Name);
        }

        /// <summary>
        /// Sorts by category
        /// </summary>
        /// <param name="product1">firstproduct</param>
        /// <param name="product2">secondproduct</param>
        /// <returns>int</returns>
        public int SortByCategory(Product product1, Product product2)
        {
            return string.Compare(product1.Category, product2.Category);
        }

        /// <summary>
        /// Sorts by category
        /// </summary>
        /// <param name="product1">firstproduct</param>
        /// <param name="product2">secondproduct</param>
        /// <returns>int</returns>
        public int SortByPrice(Product product1, Product product2)
        {
            if (product1.Price < product2.Price)
            {
                return -1;
            }
            else if (product1.Price > product2.Price)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Sorts by category
        /// </summary>
        /// <param name="products">firstproduct</param>
        /// <param name="sortDelegate">secondproduct</param>
        public void SortAndDisplay(List<Product> products, SortDelegate sortDelegate)
        {
            //products.Sort(sortDelegate);

            foreach (Product product in products)
            {
                Console.WriteLine(
                    "Name: " + product.Name +
                    ", Category: " + product.Category +
                    ", Price: " + product.Price);
            }
        }

        /// <summary>
        /// Demonstrates Record
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

            // Records are immutable
            // This is not allowed:
            // book1.Title = "New Title";

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
        /// Displays book
        /// </summary>
        /// <param name="book">book</param>
        public void DisplayBook(Book book)
        {
            var (title, author, isbn) = book;

            Console.WriteLine("Deconstructed Book:");
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("ISBN: " + isbn);
        }

        /// <summary>
        /// Demonstrates Pattern matching
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
        /// Displays shape details
        /// </summary>
        /// <param name="shape">shape</param>
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

