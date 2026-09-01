namespace Assignment8
{
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            Tasks.DemonstrateDivideByZeroException(10, 0);

            int[] numbers = new int[10]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            };

            Console.Write("Enter an index to access: ");

            int index;
            if (int.TryParse(Console.ReadLine(), out index))
            {
                Console.WriteLine($"Index: {index}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            Tasks.DemonstrateIndexOutOfRangeException(numbers);

            Tasks.DemonstrateInvalidUserInputException();

            Tasks.DemonstrateUnhandledException();

            Tasks.DemonstrateStackTrace();
        }
    }
}