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
        /// Processes input data by converting it to uppercase.
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>processed string</returns>
        public string ProcessData(string input) => string.IsNullOrEmpty(input) ? string.Empty : input.ToUpperInvariant();

        /// <summary>
        /// Reads, transforms, buffers via MemoryStream, and writes asynchronously in a single pass.
        /// </summary>
        /// <param name="inputPath">Path to the input file.</param>
        /// <param name="outputPath">Path to the output file.</param>
        /// <param name="chunkSize">Size of each read/write chunk in bytes.</param>
        /// <param name="useBufferedStream">Whether to wrap FileStream in BufferedStream for reading.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        public async Task ProcessAndWriteFileAsync(string inputPath, string outputPath, int chunkSize = 64 * 1024, bool useBufferedStream = false)
        {
            using FileStream rawInputFs = new(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read, chunkSize, useAsync: true);
            using Stream inputFs = useBufferedStream ? new BufferedStream(rawInputFs, chunkSize) : rawInputFs;
            using FileStream outputFs = new(outputPath, FileMode.Create, FileAccess.Write, FileShare.None, chunkSize, useAsync: true);

            byte[] readBuffer = new byte[chunkSize];
            int bytesRead;

            while ((bytesRead = await inputFs.ReadAsync(readBuffer, 0, readBuffer.Length)) > 0)
            {
                string chunkText = Encoding.UTF8.GetString(readBuffer, 0, bytesRead);
                byte[] processedBytes = Encoding.UTF8.GetBytes(this.ProcessData(chunkText));

                using MemoryStream memStream = new (processedBytes.Length);
                await memStream.WriteAsync(processedBytes, 0, processedBytes.Length);
                memStream.Position = 0;
                await memStream.CopyToAsync(outputFs);
            }
        }

        /// <summary>
        /// Processes multiple files concurrently without blocking.
        /// </summary>
        /// <param name="inputFiles">Array of input file paths.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        public async Task ProcessMultipleFilesConcurrentlyAsync(string[] inputFiles)
        {
            Console.WriteLine($"--- Concurrent Async Processing ({inputFiles.Length} files) ---");
            Stopwatch sw = Stopwatch.StartNew();

            Task[] tasks = inputFiles.Select((file, i) =>
                this.ProcessAndWriteFileAsync(file, $"OutputFile_{i + 1}.txt")).ToArray();

            await Task.WhenAll(tasks);

            sw.Stop();
            Console.WriteLine($"All files processed in: {sw.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// Compares Sync Sequential vs Async Concurrent batch processing.
        /// </summary>
        /// <param name="inputFiles">Array of input file paths.</param>
        /// <param name="syncProcessor">Instance of FileProcessor for synchronous processing.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        public async Task CompareSyncVsAsync(string[] inputFiles, FileProcessor syncProcessor)
        {
            Stopwatch syncSw = Stopwatch.StartNew();
            for (int i = 0; i < inputFiles.Length; i++)
            {
                syncProcessor.ProcessAndWriteLargeFile(inputFiles[i], $"SyncOutput_{i + 1}.txt");
            }

            syncSw.Stop();

            Stopwatch asyncSw = Stopwatch.StartNew();
            await this.ProcessMultipleFilesConcurrentlyAsync(inputFiles);
            asyncSw.Stop();

            Console.WriteLine($"\nSync Total: {syncSw.ElapsedMilliseconds} ms | Async Total: {asyncSw.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// Demonstrates async file processing, concurrent batch execution, and performance comparisons.
        /// </summary>
        /// <param name="sampleFile">Path to the sample file to process.</param>
        /// <param name="syncProcessor">Instance of FileProcessor for benchmark comparison.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        public async Task DemonstrateAsyncFileProcessing(string sampleFile = "SampleFile.txt", FileProcessor syncProcessor = null)
        {
            bool isMenuOpen = true;

            while (isMenuOpen)
            {
                Console.Clear();
                Console.Write(@"--- Asynchronous File Stream Processor ---

1. Process Single File (Async Stream -> Uppercase -> MemoryStream -> Write)
2. Process Multiple Files Concurrently (Async Batch)
3. Compare Performance (Sync Sequential vs Async Concurrent)
4. Back to Main Menu

Select a choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    continue;
                }

                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("--- Processing Single File (Async) ---");
                        await this.ProcessAndWriteFileAsync(sampleFile, "AsyncOutputFile.txt");
                        Console.WriteLine("Async processing completed successfully.");
                        break;

                    case 2:
                        string[] filesToProcess = { sampleFile, sampleFile, sampleFile };
                        await this.ProcessMultipleFilesConcurrentlyAsync(filesToProcess);
                        break;

                    case 3:
                        if (syncProcessor == null)
                        {
                            Console.WriteLine("Error: Synchronous processor instance is required for comparison.");
                        }
                        else
                        {
                            string[] benchmarkFiles = { sampleFile, sampleFile, sampleFile };
                            await this.CompareSyncVsAsync(benchmarkFiles, syncProcessor);
                        }

                        break;

                    case 4:
                        isMenuOpen = false;
                        continue;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}