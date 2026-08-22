namespace Assignment5.Helpers
{
    /// <summary>
    /// Class for displaying console messages in different colors.
    /// </summary>
    internal class OutputColor
    {
        /// <summary>
        /// Display error message in red color.
        /// </summary>
        /// <param name="message">Message that should be displayed.</param>
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Display success message in green color.
        /// </summary>
        /// <param name="message">Message that should be displayed.</param>
        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Display warning message in yellow color.
        /// </summary>
        /// <param name="message">Message that should be displayed.</param>
        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }
    }
}
