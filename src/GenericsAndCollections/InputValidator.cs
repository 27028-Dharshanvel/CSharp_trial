namespace GenericsAndCollections
{
    /// <summary>
    /// InputValidator class
    /// </summary>
    internal static class InputValidator
    {
        /// <summary>
        /// Validates whether a input string in an integer.
        /// </summary>
        /// <param name="input">input value</param>
        /// <param name="result">out integer result</param>
        /// <returns>True if within range, False otherwise.</returns>
        public static bool IsValidInt(string input, out int result)
        {
            return int.TryParse(input, out result);
        }

        /// <summary>
        /// Validates whether input integer is within range
        /// </summary>
        /// <param name="value">input value</param>
        /// <param name="min">minimum value</param>
        /// <param name="max">maximum value</param>
        /// <returns>True if within range, False otherwise.</returns>
        public static bool IsIntWithinRange(int value, int min, int max)
        {
            return value >= min && value <= max;
        }
    }
}
