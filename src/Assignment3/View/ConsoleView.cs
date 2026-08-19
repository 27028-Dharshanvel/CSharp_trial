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
                if ((int)userChoice == -1)
                {
                    userChoice = InventoryOperationsMenu.Exit;
                }

                switch (userChoice)
                {
                    case InventoryOperationsMenu.AddProducts:
                        {
                            Console.Clear();
                            Console.WriteLine("Enter Product Details :");

                            string productId = ConsoleInputReader.ReadString("\nProduct Id : ", "Product ID", 10, 3, "@@@");
                            if (productId == "@@@")
                            {
                                Console.WriteLine("Returning to Main menu...");
                                Console.ReadKey();
                                break;
                            }

                            string productName = ConsoleInputReader.ReadString("Product Name : ", "Product name", 10, 3, "@@@");
                            if (productName == "@@@")
                            {
                                Console.WriteLine("Returning to Main menu...");
                                Console.ReadKey();
                                break;
                            }

                            decimal productPrice = ConsoleInputReader.ReadDecimal("Product Price : ", "Price", 1, 10000000, 3, -1);
                            if (productPrice == -1)
                            {
                                Console.WriteLine("Returning to Main menu...");
                                Console.ReadKey();
                                break;
                            }

                            double productQuantity = ConsoleInputReader.ReadDouble("Product Quantity : ", "Quantity", 0, 100000, 3, -1);
                            if (productQuantity == -1)
                            {
                                Console.WriteLine("Returning to Main menu...");
                                Console.ReadKey();
                                break;
                            }

                            if (services.AddProduct(productId, productName, productPrice, productQuantity))
                            {
                                ConsoleOutputColor.Success("\nProduct Added Successfully.");
                            }
                            else
                            {
                                ConsoleOutputColor.Error("\nProduct not added.Product ID might already exist");
                            }

                            Console.ReadKey();
                            break;
                        }

                    case InventoryOperationsMenu.ViewProducts:

                        Console.Clear();

                        if (services.IsEmptyRepository())
                        {
                            Console.WriteLine("No Products Available.");
                        }
                        else
                        {
                            DisplayTable.DisplayProductTable(services.ViewProducts());
                        }

                        Console.ReadKey();
                        break;

                    case InventoryOperationsMenu.EditProducts:
                        {
                            Console.Clear();

                            Console.WriteLine("Enter Product Identification Details");

                            string productId = ConsoleInputReader.ReadString("\nProduct Id : ", "Product ID", 10, 3, "@@@");
                            if (productId == "@@@")
                            {
                                Console.WriteLine("Returning to Main menu...");
                                Console.ReadKey();
                                break;
                            }

                            string productName = ConsoleInputReader.ReadString("New product Name : ", "Product name", 10, 3, "@@@");
                            if (productName == "@@@")
                            {
                                Console.WriteLine("Returning to Main menu...");
                                Console.ReadKey();
                                break;
                            }

                            decimal productPrice = ConsoleInputReader.ReadDecimal("New Product Price : ", "Price", 1, 10000000, 3, -1);
                            if (productPrice == -1)
                            {
                                Console.WriteLine("Returning to Main menu...");
                                Console.ReadKey();
                                break;
                            }

                            double productQuantity = ConsoleInputReader.ReadDouble("New Product Quantity : ", "Quantity", 0, 100000, 3, -1);
                            if (productQuantity == -1)
                            {
                                Console.WriteLine("Returning to Main menu...");
                                Console.ReadKey();
                                break;
                            }

                            if (services.EditProduct(productId, productName, productPrice, productQuantity))
                            {
                                Console.WriteLine("\nProduct Updated Successfully.");
                            }
                            else
                            {
                                Console.WriteLine("\nProduct Not Found.");
                            }

                            Console.ReadKey();
                            break;
                        }

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
                        if (services.IsEmptyRepository())
                        {
                            Console.WriteLine("No Products Available.");
                        }
                        else
                        {
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
                        }

                        Console.ReadKey();
                        break;

                    case InventoryOperationsMenu.SortBy:

                        Console.Clear();
                        if (services.IsEmptyRepository())
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
                            if ((int)choice == -1)
                            {
                                choice = SortOptionsMenu.Back;
                            }
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
                                    Console.WriteLine("Returning to Main menu...");
                                    Console.ReadKey();
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