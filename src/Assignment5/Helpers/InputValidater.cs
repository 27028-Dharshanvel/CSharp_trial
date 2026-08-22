using System.Globalization;

namespace Assignment5.Helpers
{
    /// <summary>
    /// Class for validating user input.
    /// </summary>
    internal class InputValidater
    {
        /// <summary>
        /// Reads string and validate whether it is an integer,within range and with limited tries.
        /// </summary>
        /// <param name="message">Prompt for the user.</param>
        /// <param name="inputType">Variable name of the input </param>
        /// <param name="minValue">Inclusive lower bound of the range.</param>
        /// <param name="maxValue">Inclusive upper bound of the range.</param>
        /// <param name="maxTries">Maximum Tries user can make.</param>
        /// <param name="defaultValue">Default integer value that will be returned.</param>
        /// <returns>True if valid integer, False otherwise.</returns>
        public static bool IsValidInt(string message, string inputType, int minValue, int maxValue, int maxTries, out int defaultValue)
        {
            int value;

            while (maxTries > 0)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= minValue && value <= maxValue)
                    {
                        defaultValue = value;
                        return true;
                    }
                    else
                    {
                        maxTries--;
                        if (maxTries == 0)
                        {
                            continue;
                        }

                        OutputColor.Warn($"{inputType} should be in range of {minValue} and {maxValue}");
                        continue;
                    }
                }

                maxTries--;
                if (maxTries == 0)
                {
                    continue;
                }

                OutputColor.Warn("Please enter a valid integer.");
            }

            OutputColor.Error("\nToo many Attempts! Try again later");
            defaultValue = default(int);
            return false;
        }

        /// <summary>
        /// Reads string and validate whether it is an double,within range and with limited tries.
        /// </summary>
        /// <param name="message">Prompt for the user.</param>
        /// <param name="inputType">Variable name of the input </param>
        /// <param name="minValue">Inclusive lower bound of the range.</param>
        /// <param name="maxValue">Inclusive upper bound of the range.</param>
        /// <param name="maxTries">Maximum Tries user can make.</param>
        /// <param name="defaultValue">Default value that will be returned.</param>
        /// <returns>True if valid double, False otherwise.</returns>
        public static bool IsValidDouble(string message, string inputType, double minValue, double maxValue, int maxTries, out double defaultValue)
        {
            double value;

            while (maxTries > 0)
            {
                Console.Write(message);

                if (double.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= minValue && value <= maxValue)
                    {
                        defaultValue = value;
                        return true;
                    }
                    else
                    {
                        maxTries--;
                        if (maxTries == 0)
                        {
                            continue;
                        }

                        OutputColor.Warn($"{inputType} should be in range of {minValue} and {maxValue}");
                        continue;
                    }
                }

                maxTries--;
                if (maxTries == 0)
                {
                    continue;
                }

                OutputColor.Warn("Please enter a valid double.");
            }

            OutputColor.Error("\nToo many Attempts! Try again later");
            defaultValue = default(double);
            return false;
        }

        /// <summary>
        /// Reads string and validate whether it is an decimal,within range and with limited tries.
        /// </summary>
        /// <param name="message">Prompt for the user.</param>
        /// <param name="inputType">Variable name of the input </param>
        /// <param name="minValue">Inclusive lower bound of the range.</param>
        /// <param name="maxValue">Inclusive upper bound of the range.</param>
        /// <param name="maxTries">Maximum Tries user can make.</param>
        /// <param name="defaultValue">Default value that will be returned.</param>
        /// <returns>True if valid decimal, False otherwise.</returns>
        public static bool IsValidDecimal(string message, string inputType, decimal minValue, decimal maxValue, int maxTries, out decimal defaultValue)
        {
            decimal value;

            while (maxTries > 0)
            {
                Console.Write(message);

                if (decimal.TryParse(Console.ReadLine(), out value))
                {
                    if (value >= minValue && value <= maxValue)
                    {
                        defaultValue = value;
                        return true;
                    }
                    else
                    {
                        maxTries--;
                        if (maxTries == 0)
                        {
                            continue;
                        }

                        OutputColor.Warn($"{inputType} should be in range of {minValue} and {maxValue}");
                        continue;
                    }
                }

                maxTries--;
                if (maxTries == 0)
                {
                    continue;
                }

                OutputColor.Warn("Please enter a valid decimal.");
            }

            OutputColor.Error("\nToo many Attempts! Try again later");
            defaultValue = default(decimal);
            return false;
        }

        /// <summary>
        /// Reads string and validate null values.
        /// </summary>
        /// <param name="message">Prompt for the user.</param>
        /// <param name="value">Variable name of the value</param>
        /// <param name="maxCharacters">Maximum characters that can be entered.</param>
        /// <param name="maxTries">Maximum tries.</param>
        /// <param name="defaultValue">Default string that will be returned.</param>
        /// <returns>True if valid string, False otherwise</returns>
        public static bool IsValidString(string message, string value, int maxCharacters, int maxTries, out string defaultValue)
        {
            while (maxTries > 0)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && input.Length <= maxCharacters)
                {
                    defaultValue = input;
                    return true;
                }

                maxTries--;
                OutputColor.Warn($"{value} should neither be Null nor exceed {maxCharacters} characters.");
            }

            defaultValue = default(String);
            return false;
        }

        /// <summary>
        /// Reads string and check whether it is a valid date.
        /// </summary>
        /// <param name="message">Prompt for the user.</param>
        /// <param name="maxYearsBack">Maximum years in past from today that can be entered.</param>
        /// <param name="maxTries">Maximum tries user can make.</param>
        /// <param name="defaultDate">Default date that will be returned.</param>
        /// <returns>True if valid Date, False otherwise.</returns>
        public static bool IsValidDate(string message, int maxYearsBack, int maxTries, out DateOnly defaultDate)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            DateOnly minDate = today.AddYears(-maxYearsBack);

            while (maxTries > 0)
            {
                Console.Write($"Enter a date (yyyy-MM-dd) : ");
                string? input = Console.ReadLine();

                if (!DateOnly.TryParseExact(
                        input,
                        "yyyy-MM-dd",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateOnly date))
                {
                    OutputColor.Warn("Invalid format. Please enter date as yyyy-MM-dd.");
                    maxTries--;
                    continue;
                }

                if (date > today)
                {
                    OutputColor.Warn("Future dates are not allowed.");
                    maxTries--;
                    continue;
                }

                if (date < minDate)
                {
                    OutputColor.Warn(@$"Date cannot be older than {maxYearsBack} years.
Enter a date on or after {minDate:yyyy-MM-dd}.");
                    maxTries--;
                    continue;
                }

                defaultDate = date;
                return true;
            }

            OutputColor.Error("\nToo many Attempts! Try again later");
            defaultDate = default(DateOnly);
            return false;
        }
    }
}
