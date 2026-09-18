using System.Text;

namespace FileStreams
{
    /// <summary>
    /// Task 3: Investigates memory and performance inefficiencies in basic file usage
    /// and provides an optimized fix.
    /// </summary>
    public class BasicFileUsage
    {
        /// <summary>
        /// Starter code provided in the assignment exhibiting memory and I/O inefficiencies.
        /// </summary>
        /// <param name="path">Path to sample file.</param>
        public static void OriginalStarterCode(string path)
        {
            Console.WriteLine("Executing Original Starter Code...");
            string data = "This is some test data for Task 3.";

            // Writing to file using MemoryStream (Inefficient allocation)
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                memoryStream.Write(buffer, 0, buffer.Length);

                // Write from MemoryStream to file
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    byte[] writeBuffer = memoryStream.ToArray(); // Allocates duplicate byte array in memory
                    fileStream.Write(writeBuffer, 0, writeBuffer.Length);
                }
            }

            // Reading from file using FileStream (Inefficient byte-by-byte console output)
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Simulate memory inefficiency - character by character console writing
                    for (int i = 0; i < bytesRead; i++)
                    {
                        Console.Write((char)buffer[i]);
                    }

                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Optimized version fixing memory allocations and I/O bottlenecks.
        /// </summary>
        /// <param name="path">Path to target file.</param>
        public static void OptimizedCode(string path)
        {
            Console.WriteLine("\n[Task 3] Executing Optimized Code...");
            string data = "This is some test data for Task 3.";

            // 1. Direct File Writing without redundant MemoryStream allocations
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                fileStream.Write(buffer, 0, buffer.Length);
            }

            // 2. Efficient Reading using StreamReader / string decoding without character-by-character loops
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }
        }

        /// <summary>
        /// Prints a detailed explanation of identified issues and applied fixes.
        /// </summary>
        public static void PrintExplanation()
        {
            Console.WriteLine(" Task 3: Analysis & Explanation of Memory/I-O Issues   ");
            Console.WriteLine(@"
1. Memory Allocations (Writing Phase):
   - Issue: The starter code created an intermediate MemoryStream and then invoked memoryStream.ToArray().
            ToArray() creates a complete copy of the byte array in RAM, doubling heap allocation.
   - Fix: Write directly to FileStream using Encoding.UTF8.GetBytes(data), eliminating MemoryStream allocations.

2. I/O & CPU Inefficiency (Reading Phase):
   - Issue: The reading loop iterated byte-by-byte with `Console.Write((char)buffer[i])`. Calling Console.Write per character
            is extremely slow due to repeated string conversion and console stream flushing. Additionally, Console.WriteLine() inside
            the read loop injected unintended trailing newlines for every 1024-byte chunk.
   - Fix: Wrap the FileStream in a StreamReader or convert buffer chunks to string (Encoding.UTF8.GetString(buffer, 0, bytesRead))
          to write string chunks cleanly to Console in a single call.
");
        }

        /// <summary>
        /// Runs Task 3 demonstration.
        /// </summary>
        public static void RunDemo()
        {
            Console.WriteLine("   Task 3: Investigate Basic File Usage   ");

            string path = "task3_test.txt";
            OriginalStarterCode(path);
            OptimizedCode(path);
            PrintExplanation();

            Console.WriteLine("[Task 3 Demo Complete]\n");
        }
    }
}