using System.Diagnostics;
using System.Text;

namespace FileStreams
{
    /// <summary>
    /// Implements asynchronous methods for FileStream, BufferedStream, and MemoryStream.
    /// </summary>
    public class AsyncFileProcessor
    {
        /// <summary>
        /// Reads a file asynchronously using FileStream.
        /// </summary>
        /// <param name="filePath">Path of the file to read.</param>
        /// <param name="bufferSize">Buffer chunk size in bytes.</param>
        /// <returns>Elapsed time in milliseconds.</returns>
        public static async Task<long> ReadFileAsync(string filePath, int bufferSize = 64 * 1024)
        {
            try
            {
                Console.WriteLine($"Async reading FileStream: {Path.GetFileName(filePath)}...");
                Stopwatch stopwatch = Stopwatch.StartNew();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, useAsync: true))
                {
                    byte[] buffer = new byte[bufferSize];
                    int bytesRead;
                    long totalBytesRead = 0;

                    while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        totalBytesRead += bytesRead;
                    }
                }
                Console.WriteLine("This will print after");
                stopwatch.Stop();
                Console.WriteLine($"Async FileStream read completed for {Path.GetFileName(filePath)} in {stopwatch.ElapsedMilliseconds} ms");
                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Async read error: {ex.Message}");
                return -1;
            }
        }

        /// <summary>
        /// Reads a file asynchronously using BufferedStream wrapping a FileStream.
        /// </summary>
        /// <param name="filePath">Path of the file to read.</param>
        /// <param name="bufferSize">Buffer chunk size in bytes.</param>
        /// <returns>Elapsed time in milliseconds.</returns>
        public static async Task<long> ReadFileBufferedAsync(string filePath, int bufferSize = 64 * 1024)
        {
            try
            {
                Console.WriteLine($"Async reading BufferedStream: {Path.GetFileName(filePath)}...");
                Stopwatch stopwatch = Stopwatch.StartNew();

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, useAsync: true))
                using (BufferedStream bs = new BufferedStream(fs, bufferSize))
                {
                    byte[] buffer = new byte[bufferSize];
                    int bytesRead;
                    long totalBytesRead = 0;

                    while ((bytesRead = await bs.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        totalBytesRead += bytesRead;
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($"Async BufferedStream read completed for {Path.GetFileName(filePath)} in {stopwatch.ElapsedMilliseconds} ms");
                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Async buffered read error: {ex.Message}");
                return -1;
            }
        }

        /// <summary>
        /// Processes string content asynchronously.
        /// </summary>
        /// <param name="input">Source text data.</param>
        /// <returns>Processed string converted to uppercase asynchronously.</returns>
        public static Task<string> ProcessDataAsync(string input)
        {
            return Task.Run(() =>
            {
                if (string.IsNullOrEmpty(input))
                {
                    return string.Empty;
                }

                return input.ToUpperInvariant();
            });
        }

        /// <summary>
        /// Writes data asynchronously to a file via MemoryStream buffering.
        /// </summary>
        /// <param name="processedData">Text data to write.</param>
        /// <param name="outputPath">Output file path.</param>
        /// <returns>task</returns>
        public static async Task WriteProcessedDataAsync(string processedData, string outputPath)
        {
            try
            {
                Console.WriteLine($"Async writing processed data to: {outputPath}");
                byte[] dataBytes = Encoding.UTF8.GetBytes(processedData);

                using (MemoryStream ms = new MemoryStream())
                {
                    await ms.WriteAsync(dataBytes, 0, dataBytes.Length);
                    ms.Position = 0;

                    using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
                    {
                        await ms.CopyToAsync(fs);
                    }
                }

                Console.WriteLine($"Async write complete: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Async write error: {ex.Message}");
            }
        }

        /// <summary>
        /// Processes multiple files concurrently using Task.WhenAll.
        /// </summary>
        /// <param name="filePaths">Array of file paths to process concurrently.</param>
        /// <returns>task</returns>
        public static async Task ProcessMultipleFilesConcurrentlyAsync(string[] filePaths)
        {
            Console.WriteLine($"Starting concurrent processing of {filePaths.Length} files...");
            Stopwatch sw = Stopwatch.StartNew();

            Task[] tasks = new Task[filePaths.Length];
            for (int i = 0; i < filePaths.Length; i++)
            {
                string path = filePaths[i];
                tasks[i] = Task.Run(async () =>
                {
                    await ReadFileAsync(path);
                    string outPath = $"output_{Path.GetFileName(path)}";
                    await WriteProcessedDataAsync("CONCURRENT FILE PROCESSED DATA", outPath);
                });
            }

            await Task.WhenAll(tasks);
            sw.Stop();
            Console.WriteLine($"Concurrent processing of all files finished in {sw.ElapsedMilliseconds} ms.");
        }

        /// <summary>
        /// Demonstrates asynchronous processing and performance comparison.
        /// </summary>
        /// <returns>task</returns>
        public static async Task DemonstrateAsynchronousFileProcessing()
        {
            Console.WriteLine("       Async File Data Processor Demonstration      ");

            string file1 = "task2_file1.txt";
            string file2 = "task2_file2.txt";

            FileProcessor fileProcessor = new FileProcessor();
            fileProcessor.GenerateSampleFile(file1, 5);
            fileProcessor.GenerateSampleFile(file2, 5);

            Console.WriteLine("--- Testing Asynchronous Reading ---");
            long asyncTime = await ReadFileAsync(file1);

            Console.WriteLine("--- Testing Concurrent Processing of Multiple Files ---");
            await ProcessMultipleFilesConcurrentlyAsync(new[] { file1, file2 });

            Console.WriteLine("[Task 2 Demonstration Complete]\n");
        }
    }
}