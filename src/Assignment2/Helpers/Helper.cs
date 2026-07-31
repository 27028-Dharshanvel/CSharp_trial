using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Helpers
{
    /// <summary>
    /// Helper clas
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
        /// To Read a decimal value.
        /// </summary>
        /// <param name="message">Decimal</param>
        /// <returns>Amount in decimal.</returns>
        public static decimal ReadDecimal(string message)
        {
            decimal value;

            while (true)
            {
                Console.Write(message);

                if (decimal.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }

                Console.WriteLine("Please enter a valid decimal number.");
            }
        }
        /// <summary>
        /// To display Banking Operations
        /// </summary>
        public static void DisplayBankingOperations()
        {
            Console.WriteLine("\n 1.Deposit \n 2.Withdraw");
        }
    }
}
