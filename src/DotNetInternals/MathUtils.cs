namespace MathUtility
{
    /// <summary>
    /// Mathematic operations
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Addition operation of two integers.
        /// </summary>
        /// <param name="firstAddend">firstAddend</param>
        /// <param name="secondAddend">secondAddend</param>
        /// <returns>Sum of the input values.</returns>
        public static int Add(int firstAddend, int secondAddend)
        {
            return checked(firstAddend + secondAddend);
        }

        /// <summary>
        /// Subtraction operation of two integers.
        /// </summary>
        /// <param name="minuend">minuend</param>
        /// <param name="subtrahend">subtrahend</param>
        /// <returns>Difference of the input values</returns>
        public static int Subtract(int minuend, int subtrahend)
        {
            return checked(minuend - subtrahend);
        }

        /// <summary>
        /// Multiplication operation of two integers.
        /// </summary>
        /// <param name="multiplicand">multiplicand</param>
        /// <param name="multiplier">multiplier</param>
        /// <returns>Product of the input values.</returns>
        public static int Multiply(int multiplicand, int multiplier)
        {
            return checked(multiplicand * multiplier);
        }

        /// <summary>
        /// Division operation of two integers.
        /// </summary>
        /// <param name="dividend">Dividend</param>
        /// <param name="divisor">Divisor</param>
        /// <returns>Quotient by dividing the input values.</returns>
        public static int Divide(int dividend, int divisor)
        {
            return checked(dividend / divisor);
        }
    }
}
