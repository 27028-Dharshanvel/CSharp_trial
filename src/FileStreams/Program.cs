using System.Text;

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
        /// <param name="args">Command-Line args</param>
        public static void Main(string[] args)
        {
            {
                string filePath = "large_1gb_file.txt";

                // 1 GB target size in bytes
                long targetSizeBytes = 1L * 1024 * 1024 * 1024;

                // Define a chunk of sample text to repeat (roughly 1 KB per line block)
                string sampleLine = "This is a line of sample text used to efficiently fill a large file on the disk block by block.\n";
                byte[] sampleBytes = Encoding.UTF8.GetBytes(sampleLine);

                Console.WriteLine("Generating 1 GB file... Please wait.");
                var watch = System.Diagnostics.Stopwatch.StartNew();

                // 1. Open FileStream with a custom 64 KB buffer size for optimized disk I/O
                // 2. Wrap it in a StreamWriter for smooth text operations
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 64 * 1024))
                using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                {
                    long currentBytesWritten = 0;

                    while (currentBytesWritten < targetSizeBytes)
                    {
                        writer.Write(sampleLine);
                        currentBytesWritten += sampleBytes.Length;
                    }
                }

                watch.Stop();
                Console.WriteLine($"Success! File created at: {Path.GetFullPath(filePath)}");
                Console.WriteLine($"Time elapsed: {watch.Elapsed.TotalSeconds:F2} seconds");
            }
        }
    }
}
