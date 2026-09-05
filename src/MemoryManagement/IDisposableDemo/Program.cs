using IDisposableDemo;

namespace Assignments
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Enry point of the program
        /// </summary>
        /// <param name="args">CMD line args</param>
        public static void Main(string[] args)
        {
            string path = "example_output.txt";

            Console.WriteLine("Opening file and writing text...");

            using (SimpleFileWriter fileHandler = new SimpleFileWriter(path))
            {
                fileHandler.WriteLine("Hello, World!");
                fileHandler.WriteLine("This file is managed safely by a disposable class.");
            }

            Console.WriteLine($"Done! The file was safely closed and saved to '{path}'.");
        }
    }
}