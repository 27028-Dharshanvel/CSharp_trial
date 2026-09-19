namespace BasicCalculator
{
    /// <summary>
    /// InputValidator class
    /// </summary>
    internal static class InputValidator
    {
        /// <summary>
        /// Validates whether a input string is an integer.
        /// </summary>
        /// <param name="input">Input value</param>
        /// <param name="result">out integer result</param>
        /// <returns>True if within range, False otherwise.</returns>
        public static bool IsValidInt(string input, out int result)
        {
            return int.TryParse(input, out result);
        }

        /// <summary>
        /// Validates whether input integer is within range
        /// </summary>
        /// <param name="value">Input value</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>True if within range, False otherwise.</returns>
        public static bool IsIntWithinRange(int value, int min, int max)
        {
            return value >= min && value <= max;
        }
    }
}