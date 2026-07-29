using Assignment3.Helpers;
using Assignment3.Models;
using Assignment3.Service;

namespace Assignment3.View
{
    /// <summary>
    /// Console input and output operations
    /// </summary>
    internal static class ConsoleView
    {
        /// <summary>
        /// Console Operations
        /// </summary>
        public static void ConsoleOperations()
        {
            Services services = new Services();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("********* Inventory Management Application ************" +
                    "\n1.Add Products" +
                    "\n2.View Products" +
                    "\n3.Edit Products" +
                    "\n4.Delete Product" +
                    "\n5.Search Product" +
                    "\n6.Sort Products" +
                    "\n7.Exit");

                Choices.InventoryOperations userChoice =
                    (Choices.InventoryOperations)Helper.ReadInt(
                        "\nSelect the operation to perform : ");

                switch (userChoice)
                {
                    case Choices.InventoryOperations.AddProducts:

                        Console.Clear();

                        Console.WriteLine("Enter Product Details :");

                        if (services.AddProduct(
                            Helper.ReadString("\nProduct Id : "),
                            Helper.ReadString("Product Name : "),
                            Helper.ReadDouble("Product Price : "),
                            Helper.ReadDouble("Product Quantity : ")))
                        {
                            Console.WriteLine("\nProduct Added Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nProduct Not Added.");
                        }

                        Console.ReadKey();
                        break;

                    case Choices.InventoryOperations.ViewProducts:

                        Console.Clear();

                        List<Product> products = services.ViewProducts();

                        if (products.Count == 0)
                        {
                            Console.WriteLine("No Products Available.");
                        }
                        else
                        {
                            foreach (Product product in products)
                            {
                                Console.WriteLine("--------------------------------");
                                Console.WriteLine($"Product Id : {product.ProductId}");
                                Console.WriteLine($"Name       : {product.Name}");
                                Console.WriteLine($"Price      : {product.Price}");
                                Console.WriteLine($"Quantity   : {product.Quantity}");
                            }
                        }

                        Console.ReadKey();
                        break;

                    case Choices.InventoryOperations.EditProducts:

                        Console.Clear();

                        Console.WriteLine("Enter Product Identification Details");

                        if (services.EditProduct(
                            Helper.ReadString("Product Id : "),
                            Helper.ReadString("Existing Product Name : "),
                            Helper.ReadString("New Product Name : "),
                            Helper.ReadDouble("New Product Price : "),
                            Helper.ReadDouble("New Product Quantity : ")))
                        {
                            Console.WriteLine("\nProduct Updated Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nProduct Not Found.");
                        }

                        Console.ReadKey();
                        break;

                    case Choices.InventoryOperations.DeleteProducts:

                        Console.Clear();

                        if (services.DeleteProduct(
                            Helper.ReadString(
                                "Enter Product Id or Product Name : ")))
                        {
                            Console.WriteLine("\nProduct Deleted Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nProduct Not Found.");
                        }

                        Console.ReadKey();
                        break;

                    case Choices.InventoryOperations.SearchProducts:

                        Console.Clear();

                        List<Product> searchedProducts =
                            services.SearchProduct(
                                Helper.ReadString(
                                    "Enter Product Id or Product Name : "));

                        if (searchedProducts.Count == 0)
                        {
                            Console.WriteLine("No Products Found.");
                        }
                        else
                        {
                            foreach (Product product in searchedProducts)
                            {
                                Console.WriteLine("--------------------------------");
                                Console.WriteLine($"Product Id : {product.ProductId}");
                                Console.WriteLine($"Name       : {product.Name}");
                                Console.WriteLine($"Price      : {product.Price}");
                                Console.WriteLine($"Quantity   : {product.Quantity}");
                            }
                        }

                        Console.ReadKey();
                        break;

                    case Choices.InventoryOperations.SortBy:

                        Console.Clear();

                        Console.WriteLine("1.Sort By Name");
                        Console.WriteLine("2.Sort By Price");

                        int choice = Helper.ReadInt(
                            "\nSelect Sorting Type : ");

                        List<Product> sortedProducts =
                            services.SortProducts(choice);

                        foreach (Product product in sortedProducts)
                        {
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine($"Product Id : {product.ProductId}");
                            Console.WriteLine($"Name       : {product.Name}");
                            Console.WriteLine($"Price      : {product.Price}");
                            Console.WriteLine($"Quantity   : {product.Quantity}");
                        }

                        Console.ReadKey();
                        break;

                    case Choices.InventoryOperations.Exit:

                        return;

                    default:

                        Console.WriteLine("Invalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}