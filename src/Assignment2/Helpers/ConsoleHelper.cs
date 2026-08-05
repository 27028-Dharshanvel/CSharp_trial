using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Helpers
{
    /// <summary>
    /// Helper class
    /// </summary>
    internal class ConsoleHelper
    {
        /// <summary>
        /// Reads string and validate whether it is an integer,within range and with limited tries.
        /// </summary>
        /// <param name="message">Prompt for the user.</param>
        /// <param name="inputType">Variable name of the input </param>
        /// <param name="minValue">Inclusive lower bound of the range.</param>
        /// <param name="maxValue">Exclusive upper bound of the range.</param>
        /// <param name="maxTries">Maximum Tries user can make.</param>
        /// <param name="defaultValue">Default integer value that will be returned.</param>
        /// <returns>int</returns>
        public static int ReadInt(string message, string inputType, int minValue, int maxValue, int maxTries, int defaultValue)
        {
            int value;

            while (maxTries > 0)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= minValue && value < maxValue)
                    {
                        return value;
                    }
                    else
                    {
                        maxTries--;
                        if (maxTries == 0)
                        {
                            continue;
                        }

                        Error($"{inputType} should be in range of {minValue} and {maxValue}");
                        continue;
                    }
                }

                maxTries--;
                if (maxTries == 0)
                {
                    continue;
                }

                Error("Please enter a valid integer.");
            }

            Error("\nToo many Attempts! Try again later");
            return defaultValue;
        }

        /// <summary>
        /// Reads string and validate whether it is an double,within range and with limited tries.
        /// </summary>
        /// <param name="message">Prompt for the user.</param>
        /// <param name="inputType">Variable name of the input </param>
        /// <param name="minValue">Inclusive lower bound of the range.</param>
        /// <param name="maxValue">Exclusive upper bound of the range.</param>
        /// <param name="maxTries">Maximum Tries user can make.</param>
        /// <param name="defaultValue">Default value that will be returned.</param>
        /// <returns>Double</returns>
        public static double ReadDouble(string message, string inputType, int minValue, int maxValue, int maxTries, double defaultValue)
        {
            double value;

            while (maxTries > 0)
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= minValue && value < maxValue)
                    {
                        return value;
                    }
                    else
                    {
                        maxTries--;
                        if (maxTries == 0)
                        {
                            continue;
                        }

                        Error($"{inputType} should be in range of {minValue} and {maxValue}");
                        continue;
                    }
                }

                maxTries--;
                if (maxTries == 0)
                {
                    continue;
                }

                Error("Please enter a valid double.");
            }

            Error("\nToo many Attempts! Try again later");
            return defaultValue;
        }

        /// <summary>
        /// Reads string and validate whether it is an double,within range and with limited tries.
        /// </summary>
        /// <param name="message">Prompt for the user.</param>
        /// <param name="inputType">Variable name of the input </param>
        /// <param name="minValue">Inclusive lower bound of the range.</param>
        /// <param name="maxValue">Exclusive upper bound of the range.</param>
        /// <param name="maxTries">Maximum Tries user can make.</param>
        /// <param name="defaultValue">Default value that will be returned.</param>
        /// <returns>Double</returns>
        public static decimal ReadDecimal(string message, string inputType, int minValue, int maxValue, int maxTries, decimal defaultValue)
        {
            decimal value;

            while (maxTries > 0)
            {
                Console.Write(message);

                if (decimal.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= minValue && value < maxValue)
                    {
                        return value;
                    }
                    else
                    {
                        maxTries--;
                        if (maxTries == 0)
                        {
                            continue;
                        }

                        Error($"{inputType} should be in range of {minValue} and {maxValue}");
                        continue;
                    }
                }

                maxTries--;
                if (maxTries == 0)
                {
                    continue;
                }

                Error("Please enter a valid decimal.");
            }

            Error("\nToo many Attempts! Try again later");
            return defaultValue;
        }

        /*/// <summary>
        /// Reads string and validate whether it is double.
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
        /// Reads string and validate whether it is decimal.
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
        */

        /// <summary>
        /// Addproduct
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="value">input</param>
        /// <param name="maxCharacters">maxCharacters</param>
        /// <param name="maxTries">maxTries</param>
        /// <param name="defaultValue">defaultValue</param>
        /// <returns>string.</returns>
        public static string ReadString(string message, string value, int maxCharacters, int maxTries, string defaultValue)
        {
            while (maxTries > 0)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && input.Length <= maxCharacters)
                {
                    return input;
                }

                maxTries--;
                Error($"{value} should neither be Null nor exceed {maxCharacters} characters.");
            }

            return defaultValue;
        }

        /// <summary>
        /// Display error message in red color.
        /// </summary>
        /// <param name="message">message</param>
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// To display Banking Operations.
        /// </summary>
        public static void DisplayBankingOperations()
        {
            Console.WriteLine("\n 1.Deposit " +
                "\n 2.Withdraw");
        }
    }
}
