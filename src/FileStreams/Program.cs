using System;
using System.Threading.Tasks;

namespace FileStreams
{
    /// <summary>
    /// Entry point for the FileStreams assignment application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main application entry point.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>Task</returns>
        public static async Task Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.Write(@"------------ Working with Files and Streams ----------------

1. File Data Processor (Synchronous)
2. File Data Processor (Asynchronous)
3. Investigate Basic File Usage & Fixes
4. Demonstrate Logger & Load Testing
5. Exit

Select an operation to perform : ");

                string? input = Console.ReadLine();
                Console.WriteLine();
                Console.Clear();
                switch (input?.Trim())
                {
                    case "1":
                        FileProcessor fileprocessor = new FileProcessor();
                        fileprocessor.DemonstrateFileDataProcessing();
                        PressAnyKeyToContinue();
                        break;
                    case "2":
                        AsyncFileProcessor asyncFileProcessor = new AsyncFileProcessor();
                        await asyncFileProcessor.DemonstrateAsyncFileProcessing();
                        PressAnyKeyToContinue();
                        break;
                    case "3":
                        BasicFileUsage.DemonstrateFileUsage();
                        PressAnyKeyToContinue();
                        break;
                    case "4":
                        Logger.PerformanceTest();
                        PressAnyKeyToContinue();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting application.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        PressAnyKeyToContinue();
                        break;
                }
            }
        }

        private static void PressAnyKeyToContinue()
        {
            Console.WriteLine("\nPress Enter to return to the main menu...");
            Console.ReadLine();
        }
    }
}