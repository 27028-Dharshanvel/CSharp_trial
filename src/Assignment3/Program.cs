using Assignment3.Inventory;
using Assignment3.View;

namespace Assignment3
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args">Command Line Arguments</param>
        public static void Main(string[] args)
        {
            ProductInventory inventory = new ProductInventory();
            ConsoleView.ConsoleOperations(inventory);
        }
    }
}