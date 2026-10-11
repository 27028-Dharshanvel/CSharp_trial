namespace Reflections
{
    /// <summary>
    /// Calculator service
    /// </summary>
    internal interface ICalculatorService
    {
        /// <summary>
        /// Addition method
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="b">b</param>
        /// <returns>int</returns>
        int Add(int a, int b);

        /// <summary>
        /// Gets status
        /// </summary>
        /// <returns>string</returns>
        string GetStatus();
    }
}
