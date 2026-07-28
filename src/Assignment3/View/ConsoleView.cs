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
            while(true) 
            {
                Console.WriteLine("********* Inventory Management Application ************" +
                    "\n\n1.Add products" +
                    "\n2.View Products" +
                    "\n3.Edit product" + 
                    "\n4.Delete Product");
                Choices.InventoryOperations userChoice = (Choices.InventoryOperations)Helper.ReadInt("\nSelect the operation to perform : ");
                Services services = new Services();
                switch (userChoice)
                {
                    case Choices.InventoryOperations.AddProducts:
                        Console.Clear();
                        Console.WriteLine("Enter the Product Details : ");
                        if (services.AddProduct(
                            Helper.ReadString("\nProduct name : "),
                            Helper.ReadDouble("\nProduct price : "),
                            Helper.ReadDouble("\nProduct Quantity : ")))
                        {
                            Console.WriteLine("Product added to Inventory");
                        }
                        else
                        {
                            Console.WriteLine("Product not added to Inventory");
                        }

                        Console.ReadKey();
                        break;

                    case Choices.InventoryOperations.ViewProducts:
                        var products = services.ViewProducts();
                        foreach (var product in products)
                        {
                            Console.WriteLine(product.Name);
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    } 
}
