using Assignment3.Helpers;
using Assignment3.Inventory;
using Assignment3.Models;
using Assignment3.Service;
using ConsoleTables;

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

            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"********* Inventory Management Application ************
1.Add Products
2.View Products
3.Edit Products
4.Delete Product
5.Search Product
6.Sort Products
7.Exit");
                InventoryOperations userChoice =
                    (InventoryOperations)InputReader.ReadInt(
                        "\nSelect the operation to perform : ", "Choice", 1, 8, 3, -1);

                switch (userChoice)
                {
                    case InventoryOperations.AddProducts:

                        Console.Clear();
                        Console.WriteLine("Enter Product Details :");

                        if (services.AddProduct(
                                InputReader.ReadString("\nProduct Id : ", "Product ID", 10, 3, "@@@"),
                                InputReader.ReadString("Product Name : ", "Product name", 10, 3, "@@@"),
                                InputReader.ReadDecimal("Product Price : ", "Price", 1, 10000000, 3, -1),
                                InputReader.ReadDouble("Product Quantity : ", "Quantity", 0, 100000, 3, -1)))
                        {
                                InputReader.Success("\nProduct Added Successfully.");
                        }
                        else
                        {
                                InputReader.Error("\nProduct not added.Product ID might already exist");
                        }

                        Console.ReadKey();
                        break;

                    case InventoryOperations.ViewProducts:

                        Console.Clear();

                        List<Product> products = services.ViewProducts();

                        if (products.Count == 0)
                        {
                            Console.WriteLine("No Products Available.");
                        }
                        else
                        {
                            var table1 = new ConsoleTable("ProductID", "ProductName", "Price", "Quantity");
                            foreach (Product product in products)
                            {
                                table1.AddRow(product.ProductId,  product.Name, product.Price, product.Quantity);
                            }

                            table1.Write();
                        }

                        Console.ReadKey();
                        break;

                    case InventoryOperations.EditProducts:

                        Console.Clear();

                        Console.WriteLine("Enter Product Identification Details");

                        if (services.EditProduct(
                            InputReader.ReadString("Product Id : ", "Product Id", 10, 3, "@@@"),
                            InputReader.ReadString("New Product Name : ", "Product name", 20, 3, "@@@"),
                            InputReader.ReadDecimal("New Product Price : ", "Price", 1, 1000000, 3, -1),
                            InputReader.ReadDouble("New Product Quantity : ", "Quantity", 1, 100000, 3, -1)))
                        {
                            Console.WriteLine("\nProduct Updated Successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nProduct Not Found.");
                        }

                        Console.ReadKey();
                        break;

                    case InventoryOperations.DeleteProducts:

                        Console.Clear();

                        if (services.DeleteProduct(
                            InputReader.ReadString(
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

                    case InventoryOperations.SearchProducts:

                        Console.Clear();

                        List<Product> searchedProducts =
                            services.SearchProduct(
                                InputReader.ReadString(
                                    "Enter Product Id or Product Name : ", "Input", 20, 3, "@@@"));

                        if (searchedProducts.Count == 0)
                        {
                            Console.WriteLine("No Products Found.");
                        }
                        else
                        {
                            var table2 = new ConsoleTable("ProductID", "ProductName", "Price", "Quantity");
                            foreach (Product product in searchedProducts)
                            {
                                table2.AddRow(product.ProductId, product.Name, product.Price, product.Quantity);
                            }

                            table2.Write();
                        }

                        Console.ReadKey();
                        break;

                    case InventoryOperations.SortBy:

                        Console.Clear();

                        Console.WriteLine("1.Sort By Name");
                        Console.WriteLine("2.Sort By Price");

                        int choice = InputReader.ReadInt("\nSelect Sorting Type : ", "Choice", 1, 3, 3, -1);

                        List<Product>? sortedProducts =
                        services.SortProducts(choice);

                        if (sortedProducts == null)
                        {
                            InputReader.Error("Inventory is empty");
                            break;
                        }

                        foreach (Product product in sortedProducts)
                        {
                                Console.WriteLine(@$"--------------------------------
Product Id : {product.ProductId}
Name       : {product.Name}
Price      : {product.Price}
Quantity   : {product.Quantity}");
                        }

                        Console.ReadKey();
                        break;

                    case InventoryOperations.Exit:

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