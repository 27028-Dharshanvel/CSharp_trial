namespace MathUtility
{
    /// <summary>
    /// Mathematic operations
    /// </summary>
    internal class MathUtils
    {
        /// <summary>
        /// Addition operation of two integers.
        /// </summary>
        /// <param name="addend1">addend1</param>
        /// <param name="addend2">addend2</param>
        /// <returns>sum of the addends</returns>
        public static int Add(int addend1, int addend2)
        {
            return addend1 + addend2;
        }

        /// <summary>
        /// Addition operation of two integers.
        /// </summary>
        /// <param name="minuend">addend1</param>
        /// <param name="subtrahend">addend2</param>
        /// <returns>sum of the addends</returns>
        public static int Subtract(int minuend, int subtrahend)
        {
            return minuend - subtrahend;
        }

        /// <summary>
        /// Addition operation of two integers.
        /// </summary>
        /// <param name="multiplicand">addend1</param>
        /// <param name="multiplier">addend2</param>
        /// <returns>sum of the addends</returns>
        public static int Multiply(int multiplicand, int multiplier)
        {
            return multiplicand * multiplier;
        }

        /// <summary>
        /// Addition operation of two integers.
        /// </summary>
        /// <param name="dividend">addend1</param>
        /// <param name="divisor">addend2</param>
        /// <returns>sum of the addends</returns>
        public static int Divide(int dividend, int divisor)
        {
            return dividend / divisor;
        }
    }
}
