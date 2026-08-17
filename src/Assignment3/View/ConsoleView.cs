using Assignment3.Helpers;
using Assignment3.Inventory;
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
        /// <param name="inventory">inventory</param>
        public static void ConsoleOperations(ProductInventory inventory)
        {
            Services services = new Services(inventory);
            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.Clear();
                Console.WriteLine(@"********* Inventory Management Application ************
1.Add Product
2.View Products
3.Edit Products
4.Delete Product
5.Search Product
6.Sort Products
7.Exit");
                InventoryOperationsMenu userChoice =
                    (InventoryOperationsMenu)ConsoleInputReader.ReadInt(
                        "\nSelect the operation to perform : ", "Choice", 1, 8, 3, -1);

                switch (userChoice)
                {
                    case InventoryOperationsMenu.AddProducts:

                        Console.Clear();
                        Console.WriteLine("Enter Product Details :");

                        if (services.AddProduct(
                                ConsoleInputReader.ReadString("\nProduct Id : ", "Product ID", 10, 3, "@@@"),
                                ConsoleInputReader.ReadString("Product Name : ", "Product name", 10, 3, "@@@"),
                                ConsoleInputReader.ReadDecimal("Product Price : ", "Price", 1, 10000000, 3, -1),
                                ConsoleInputReader.ReadDouble("Product Quantity : ", "Quantity", 0, 100000, 3, -1)))
                        {
                                ConsoleOutputColor.Success("\nProduct Added Successfully.");
                        }
                        else
                        {
                                ConsoleOutputColor.Error("\nProduct not added.Product ID might already exist");
                        }

                        Console.ReadKey();
                        break;

                    case InventoryOperationsMenu.ViewProducts:

                        Console.Clear();

                        List<Product> products = services.ViewProducts();

                        if (products.Count == 0)
                        {
                            Console.WriteLine("No Products Available.");
                        }
                        else
                        {
                            DisplayTable.DisplayProductTable(products);
                        }

                        Console.ReadKey();
                        break;

                    case InventoryOperationsMenu.EditProducts:

                        Console.Clear();

                        Console.WriteLine("Enter Product Identification Details");

                        if (services.EditProduct(
                            ConsoleInputReader.ReadString("Product Id : ", "Product Id", 10, 3, "@@@"),
                            ConsoleInputReader.ReadString("New Product Name : ", "Product name", 20, 3, "@@@"),
                            ConsoleInputReader.ReadDecimal("New Product Price : ", "Price", 1, 1000000, 3, -1),
                            ConsoleInputReader.ReadDouble("New Product Quantity : ", "Quantity", 1, 100000, 3, -1)))
                        {
                            Console.WriteLine("\nProduct Updated Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nProduct Not Found.");
                        }

                        Console.ReadKey();
                        break;

                    case InventoryOperationsMenu.DeleteProducts:

                        Console.Clear();

                        if (services.DeleteProduct(
                            ConsoleInputReader.ReadString(
                                "Enter Product Id or Product Name : ", "Product Id or name", 20, 3, "@@@")))
                        {
                            Console.WriteLine("\nProduct Deleted Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nProduct Not Found.");
                        }

                        Console.ReadKey();
                        break;

                    case InventoryOperationsMenu.SearchProducts:

                        Console.Clear();

                        List<Product> searchedProducts =
                            services.SearchProduct(
                                ConsoleInputReader.ReadString(
                                    "Enter Product Id or Product Name : ", "Input", 20, 3, "@@@"));

                        if (searchedProducts.Count == 0)
                        {
                            Console.WriteLine("No Products Found.");
                        }
                        else
                        {
                            DisplayTable.DisplayProductTable(searchedProducts);
                        }

                        Console.ReadKey();
                        break;

                    case InventoryOperationsMenu.SortBy:

                        Console.Clear();
                        if (services.ViewProducts().Count == 0)
                        {
                            ConsoleOutputColor.Warn("Inventory is Empty!!! No products available to sort");
                            Console.ReadKey();
                            break;
                        }

                        bool isSortMenuRunning = true;

                        while (isSortMenuRunning)
                        {
                            Console.Clear();
                            Console.WriteLine(@"1.Sort By Name
2.Sort By Price
3.Back");

                            SortOptionsMenu choice = (SortOptionsMenu)ConsoleInputReader.ReadInt("\nSelect Sorting Type : ", "Choice", 1, 4, 3, -1);

                            switch (choice)
                            {
                                case SortOptionsMenu.SortByName:
                                    DisplayTable.DisplayProductTable(services.SortByName());
                                    Console.ReadKey();
                                    break;

                                case SortOptionsMenu.SortByPrice:
                                    DisplayTable.DisplayProductTable(services.SortByPrice());
                                    Console.ReadKey();
                                    break;

                                case SortOptionsMenu.Back:
                                    isSortMenuRunning = false;
                                    break;
                            }
                        }

                        break;

                    case InventoryOperationsMenu.Exit:

                        Console.WriteLine("Application Exiting .....Press any key to confirm Exit");
                        Console.ReadKey();
                        isAppRunning = false;
                        break;

                    default:

                        ConsoleOutputColor.Error("Application Exiting");
                        isAppRunning = false;
                        break;
                }
            }
        }
    }
}