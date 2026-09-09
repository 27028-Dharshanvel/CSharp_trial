namespace Assignment4.Helpers
{
    /// <summary>
    /// Class for console helper
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// It returns to main menu
        /// </summary>
        public static void ReturnToMainMenu()
        {
            Console.WriteLine("Logging out");
            Console.ReadKey();
            return;
        }

        /// <summary>
        /// It returns to transaction menu
        /// </summary>
        public static void ReturnToTransactionMenu()
        {
            Console.WriteLine("Returning to Transaction menu...");
            Console.ReadKey();
            return;
        }
    }
}
