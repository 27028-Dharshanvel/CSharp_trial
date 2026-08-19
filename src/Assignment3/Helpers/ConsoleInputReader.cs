namespace Assignment3.Helpers
{
    /// <summary>
    /// InputReader class for reading and validating user input from the console.
    /// </summary>
    internal class ConsoleInputReader
    {
        /// <summary>
        /// Generic delegate for TryParse methods.
        /// </summary>
        private delegate bool TryParseDelegate<T>(string? input, out T value);

        /// <summary>
        /// Reads and validates string input.
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="valueName">valueName</param>
        /// <param name="maxCharacters">maxcharacters</param>
        /// <param name="maxTries">maxtries</param>
        /// <param name="defaultValue">defautlvalue</param>
        /// <returns>string</returns>
        public static string ReadString(
            string message,
            string valueName,
            int maxCharacters,
            int maxTries,
            string defaultValue)
        {
            while (maxTries > 0)
            {
                Console.Write(message);

                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) &&
                    input.Length <= maxCharacters)
                {
                    return input;
                }

                maxTries--;

                if (maxTries > 0)
                {
                    ConsoleOutputColor.Warn(
                        $"{valueName} should neither be null nor exceed {maxCharacters} characters.");
                }
            }

            ConsoleOutputColor.Error("\nToo many Attempts! Try again later");
            return defaultValue;
        }

        /// <summary>
        /// Reads and validates integer input.
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="inputType">inputytpe</param>
        /// <param name="minValue">minvalue</param>
        /// <param name="maxValue">maxvalue</param>
        /// <param name="maxTries">maxtries</param>
        /// <param name="defaultValue">defaultvalue</param>
        /// <returns>integer</returns>
        public static int ReadInt(
            string message,
            string inputType,
            int minValue,
            int maxValue,
            int maxTries,
            int defaultValue)
        {
            return ReadNumber(
                message,
                inputType,
                minValue,
                maxValue,
                maxTries,
                defaultValue,
                int.TryParse);
        }

        /// <summary>
        /// Reads and validates double input.
        /// </summary>
        /// /// <param name="message">message</param>
        /// <param name="inputType">inputytpe</param>
        /// <param name="minValue">minvalue</param>
        /// <param name="maxValue">maxvalue</param>
        /// <param name="maxTries">maxtries</param>
        /// <param name="defaultValue">defaultvalue</param>
        /// <returns>integer</returns>
        public static double ReadDouble(
            string message,
            string inputType,
            double minValue,
            double maxValue,
            int maxTries,
            double defaultValue)
        {
            return ReadNumber(
                message,
                inputType,
                minValue,
                maxValue,
                maxTries,
                defaultValue,
                double.TryParse);
        }

        /// <summary>
        /// Reads and validates decimal input.
        /// </summary>
        /// /// <param name="message">message</param>
        /// <param name="inputType">inputytpe</param>
        /// <param name="minValue">minvalue</param>
        /// <param name="maxValue">maxvalue</param>
        /// <param name="maxTries">maxtries</param>
        /// <param name="defaultValue">defaultvalue</param>
        /// <returns>integer</returns>
        public static decimal ReadDecimal(
            string message,
            string inputType,
            decimal minValue,
            decimal maxValue,
            int maxTries,
            decimal defaultValue)
        {
            return ReadNumber(
                message,
                inputType,
                minValue,
                maxValue,
                maxTries,
                defaultValue,
                decimal.TryParse);
        }

        /// <summary>
        /// Generic method for reading numeric values.
        /// </summary>
        private static T ReadNumber<T>(
            string message,
            string inputType,
            T minValue,
            T maxValue,
            int maxTries,
            T defaultValue,
            TryParseDelegate<T> tryParse)
            where T : IComparable<T>
        {
            while (maxTries > 0)
            {
                Console.Write(message);

                string? input = Console.ReadLine();

                if (tryParse(input, out T value))
                {
                    if (value.CompareTo(minValue) >= 0 &&
                        value.CompareTo(maxValue) < 0)
                    {
                        return value;
                    }

                    maxTries--;

                    if (maxTries > 0)
                    {
                        ConsoleOutputColor.Warn(
                            $"{inputType} should be in range of {minValue} and {maxValue}");
                    }

                    continue;
                }

                maxTries--;

                if (maxTries > 0)
                {
                    ConsoleOutputColor.Warn(
                        $"Please enter a valid {typeof(T).Name.ToLower()}.");
                }
            }

            ConsoleOutputColor.Error("\nToo many Attempts! Try again later");
            return defaultValue;
        }
    }
}