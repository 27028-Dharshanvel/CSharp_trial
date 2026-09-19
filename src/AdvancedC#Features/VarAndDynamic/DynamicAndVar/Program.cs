using System.Diagnostics.CodeAnalysis;

namespace Assignments
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args">CMd line args</param>
        public static void Main(string[] args)
        {
            var variableInput = "Dharshan vel";
            Console.WriteLine(variableInput);

            dynamic dynamicInput = "Dharshan vel";
            Console.WriteLine(dynamicInput);
            dynamicInput = 10;
            Console.WriteLine(dynamicInput);
        }
    }
}