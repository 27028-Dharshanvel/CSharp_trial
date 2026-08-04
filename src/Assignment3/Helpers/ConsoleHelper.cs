using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Helpers
{
    /// <summary>
    /// ConsoleHelper
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// Addproduct
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="value">input</param>
        /// <param name="maxCharacters">maxCharacters</param>
        /// <param name="maxTries">maxTries</param>
        /// <returns>string.</returns>
        public static string ReadString(string message, string value, int maxCharacters, int maxTries)
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
                Helper.Error($"{value} should neither be Null nor exceed {maxCharacters} characters.");
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads string and validate whether it is decimal
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="input">input</param>
        /// <param name="maxCharacters">maxCharacters</param>
        /// <param name="maxTries">maxTries</param>
        /// <returns>decimal.</returns>
        public static int ReadInt(string message, string input, int maxCharacters, int maxTries)
        {
            int value;
            while (maxTries > 0)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out value))
                {
                    if (value < maxCharacters)
                    {
                        return value;
                    }
                    else
                    {
                        Helper.Error($"{input} should neither be Null nor exceed {maxCharacters}.");
                        maxTries--;
                        continue;
                    }
                }

                Helper.Error("Please enter a valid integer.");
                maxTries--;
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads string and validate whether it is decimal
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="input">input</param>
        /// <param name="maxCharacters">maxCharacters</param>
        /// <param name="maxTries">maxTries</param>
        /// <returns>decimal.</returns>
        public static decimal ReadDecimal(string message, string input, int maxCharacters, int maxTries)
        {
            decimal value;
            while (maxTries > 0)
            {
                Console.Write(message);

                if (decimal.TryParse(Console.ReadLine(), out value))
                {
                    if (value < maxCharacters)
                    {
                        return value;
                    }
                    else
                    {
                        Helper.Error($"{input} should neither be Null nor exceed {maxCharacters}.");
                        maxTries--;
                        continue;
                    }
                }

                Helper.Error("Please enter a valid decimal.");
                maxTries--;
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads string and validate whether it is decimal
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="input">input</param>
        /// <param name="maxCharacters">maxCharacters</param>
        /// <param name="maxTries">maxTries</param>
        /// <returns>decimal.</returns>
        public static double ReadDouble(string message, string input, int maxCharacters, int maxTries)
        {
            double value;
            while (maxTries > 0)
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out value))
                {
                    if (value < maxCharacters)
                    {
                        return value;
                    }
                    else
                    {
                        Helper.Error($"{input} should neither be Null nor exceed {maxCharacters}.");
                        maxTries--;
                        continue;
                    }
                }

                Helper.Error("Please enter a valid decimal.");
                maxTries--;
            }

            throw new NotImplementedException();
        }
    }
}
