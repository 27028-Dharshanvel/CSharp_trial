using IDisposableDemo;

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
        /// <param name="args">CMD line args</param>
        public static void Main(string[] args)
        {
            string path = "DisposableFile.txt";

            Console.WriteLine("Opening file and writing text using SimpleFileWriter...");
            using (SimpleFileWriter fileHandler = new SimpleFileWriter(path))
            {
                fileHandler.WriteLine("Hello, World!");
                fileHandler.WriteLine(@"This is a sample text to write in the file, 
The file is managed safely by a disposable class.");
            }

            Console.WriteLine($"The file was safely closed and saved to '{path}'.\n");

            Console.WriteLine("Attempting to open and read the file to verify release.");
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string content = reader.ReadToEnd();

                    Console.WriteLine("Success! The file was successfully read. Contents below:\n");
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine(content);
                    Console.WriteLine("--------------------------------------------------");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Failure! Could not read the file because it is still locked: {ex.Message}");
            }
        }
    }
}