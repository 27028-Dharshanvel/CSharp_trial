using System.Text;

namespace FileStreams
{
    /// <summary>
    /// Investigates memory and performance inefficiencies in basic file usage
    /// </summary>
    public class BasicFileUsage
    {
        /// <summary>
        /// Starter code provided in the assignment exhibiting memory and I/O inefficiencies.
        /// </summary>
        /// <param name="path">Path to sample file.</param>
        public static void BasicFileProcessing(string path)
        {
            Console.WriteLine("Executing Original Starter Code...");
            string data = "This is some test data for Task 3.";

            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                memoryStream.Write(buffer, 0, buffer.Length);

                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    byte[] writeBuffer = memoryStream.ToArray();
                    fileStream.Write(writeBuffer, 0, writeBuffer.Length);
                }
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
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
        public static void OptimizedFileProcessing(string path)
        {
            Console.WriteLine("Executing Optimized Code...");
            string data = "This is some test data.";

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                fileStream.Write(buffer, 0, buffer.Length);
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine(content);
            }
        }

        /// <summary>
        /// Demonstration of Basic file usage
        /// </summary>
        public static void DemonstrateBasicFileUsage()
        {
            Console.WriteLine(" -------------- Investigate Basic File Usage ----------------  ");

            string path = "task3_test.txt";
            BasicFileProcessing(path);
            OptimizedFileProcessing(path);

            Console.WriteLine("Demonstration is Complete");
        }
    }
}