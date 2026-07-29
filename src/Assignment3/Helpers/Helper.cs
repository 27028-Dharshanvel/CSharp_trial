namespace Assignment3.Helpers
{
    /// <summary>
    /// Helper
    /// </summary>
    internal class Helper
    {
        /// <summary>
        /// Reads string and validate whether it is int
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>int</returns>
        public static int ReadInt(string message)
        {
            int value;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }

                Console.WriteLine("Please enter a valid integer.");
            }
        }

        /// <summary>
        /// Reads string and validate whether it is double
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>double</returns>
        public static double ReadDouble(string message)
        {
            double value;

            while (true)
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }

                Console.WriteLine("Please enter a valid integer.");
            }
        }

        /// <summary>
        /// Reads string
        /// </summary>
        /// <param name="message">message</param>
        /// <returns>string</returns>
        public static string ReadString(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Displays success message in green color.
        /// </summary>
        /// <param name="message">message</param>
        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }
    }
}
