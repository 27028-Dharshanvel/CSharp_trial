namespace Assignment3.Helpers
{
    /// <summary>
    /// InputReader class
    /// </summary>
    internal class ConsoleInputReader
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
        /// <returns>Integer</returns>
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

                        ConsoleOutputColor.Warn($"{inputType} should be in range of {minValue} and {maxValue}");
                        continue;
                    }
                }

                maxTries--;
                if (maxTries == 0)
                {
                    continue;
                }

                ConsoleOutputColor.Warn("Please enter a valid integer.");
            }

            ConsoleOutputColor.Error("\nToo many Attempts! Try again later");
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
        public static double ReadDouble(string message, string inputType, double minValue, double maxValue, int maxTries, double defaultValue)
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

                        ConsoleOutputColor.Warn($"{inputType} should be in range of {minValue} and {maxValue}");
                        continue;
                    }
                }

                maxTries--;
                if (maxTries == 0)
                {
                    continue;
                }

                ConsoleOutputColor.Warn("Please enter a valid double.");
            }

            ConsoleOutputColor.Error("\nToo many Attempts! Try again later");
            return defaultValue;
        }

        /// <summary>
        /// Reads string and validate whether it is an decimal,within range and with limited tries.
        /// </summary>
        /// <param name="message">Prompt for the user.</param>
        /// <param name="inputType">Variable name of the input </param>
        /// <param name="minValue">Inclusive lower bound of the range.</param>
        /// <param name="maxValue">Exclusive upper bound of the range.</param>
        /// <param name="maxTries">Maximum Tries user can make.</param>
        /// <param name="defaultValue">Default value that will be returned.</param>
        /// <returns>Decimal</returns>
        public static decimal ReadDecimal(string message, string inputType, decimal minValue, decimal maxValue, int maxTries, decimal defaultValue)
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

                        ConsoleOutputColor.Warn($"{inputType} should be in range of {minValue} and {maxValue}");
                        continue;
                    }
                }

                maxTries--;
                if (maxTries == 0)
                {
                    continue;
                }

                ConsoleOutputColor.Warn("Please enter a valid decimal.");
            }

            ConsoleOutputColor.Error("\nToo many Attempts! Try again later");
            return defaultValue;
        }

        /// <summary>
        /// Reads string and validate null values.
        /// </summary>
        /// <param name="message">Prompt for the user.</param>
        /// <param name="value">Variable name of the value</param>
        /// <param name="maxCharacters">Maximum characters that can be entered.</param>
        /// <param name="maxTries">Maximum tries.</param>
        /// <param name="defaultValue">Default string that will be returned.</param>
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
                ConsoleOutputColor.Warn($"{value} should neither be Null nor exceed {maxCharacters} characters.");
            }

            return defaultValue;
        }
    }
}
