using System;
using System.Threading.Tasks;

namespace FileStreams
{
    /// <summary>
    /// Entry point for the FileStreams assignment application.
    /// Provides an interactive console menu to execute and evaluate each task.
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
            Console.Title = "C# Files and Streams Assignment Solution";

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.Write(@"------------Working with Files and Streams in C#----------------

1. File Data Processor (Synchronous)
2. File Data Processor (Asynchronous)
3. Investigate Basic File Usage & Fixes
4. Multi-User Logger & Load Testing
5. Exit

Select an operation to perform : ");

                string? input = Console.ReadLine();
                Console.WriteLine();

                switch (input?.Trim())
                {
                    case "1":
                        FileProcessor fileprocessor = new FileProcessor();
                        fileprocessor.DeomstrateFileDataProcessing();
                        PressAnyKeyToContinue();
                        break;
                    case "2":
                        await AsyncFileProcessor.DemonstrateAsynchronousFileProcessing();
                        PressAnyKeyToContinue();
                        break;
                    case "3":
                        BasicFileUsage.DemonstrateBasicFileUsage();
                        PressAnyKeyToContinue();
                        break;
                    case "4":
                        Logger.DemonstrateLogger();
                        PressAnyKeyToContinue();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Exiting application. Goodbye!");
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