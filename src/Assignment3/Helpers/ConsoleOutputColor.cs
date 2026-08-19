using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Helpers
{
    /// <summary>
    /// ConsoleOutputColor class for displaying messages in different colors.
    /// </summary>
    internal class ConsoleOutputColor
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
