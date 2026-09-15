using Assignment3.Inventory;
using Assignment3.View;

namespace Assignment3
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the application. Initializes the ProductInventory and starts the console operations.
        /// </summary>
        /// <param name="args">Command Line Arguments</param>
        public static void Main(string[] args)
        {
            ProductInventory inventory = new ProductInventory();
            ConsoleView.ConsoleOperations(inventory);
        }
    }
}