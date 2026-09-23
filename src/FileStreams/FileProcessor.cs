using System.Diagnostics;
using System.Text;

namespace FileStreams
{
    /// <summary>
    /// File processing implementation using FileStream, BufferedStream, and MemoryStream chunking.
    /// </summary>
    public class FileProcessor
    {
        private const string SampleFile = "SampleFile.txt";
        private const string OutputFile = "OutputFile.txt";

        /// <summary>
        /// Generates a sample text file of specified size in megabytes.
        /// </summary>
        /// <param name="filePath">Target path for the sample file.</param>
        /// <param name="sizeInMb">File size target in megabytes.</param>
        public void GenerateSampleFile(string filePath = SampleFile, int sizeInMb = 1024)
        {
            Console.WriteLine($"Generating {sizeInMb} MB sample file at: {filePath}");
            byte[] lineBytes = Encoding.UTF8.GetBytes("Sample data for stream processing performance tests.\n");
            long targetBytes = (long)sizeInMb * 1024 * 1024;

            using FileStream fs = new (filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            for (long written = 0; written < targetBytes; written += lineBytes.Length)
            {
                fs.Write(lineBytes, 0, lineBytes.Length);
            }

            Console.WriteLine("Sample file generated successfully.");
        }

        /// <summary>
        /// Reads a file in chunks using standard FileStream and measures execution time.
        /// </summary>
        /// <param name="filePath">Path of the target file.</param>
        /// <param name="bufferSize">Buffer size in bytes.</param>
        /// <returns>Elapsed time in milliseconds.</returns>
        public long ReadFileWithFileStream(string filePath = SampleFile, int bufferSize = 64 * 1024)
        {
            Stopwatch sw = Stopwatch.StartNew();
            using FileStream fs = new (filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize);
            byte[] buffer = new byte[bufferSize];
            while (fs.Read(buffer, 0, buffer.Length) > 0)
            {
            }

            sw.Stop();
            Console.WriteLine($"FileStream Read ({bufferSize / 1024} KB buffer): {sw.ElapsedMilliseconds} ms");
            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// Reads a file using BufferedStream wrapping a FileStream and measures performance.
        /// </summary>
        /// <param name="filePath">Path of the target file.</param>
        /// <param name="bufferSize">Buffer size in bytes.</param>
        /// <returns>Elapsed time in milliseconds.</returns>
        public long ReadFileWithBufferedStream(string filePath = SampleFile, int bufferSize = 64 * 1024)
        {
            Stopwatch sw = Stopwatch.StartNew();
            using FileStream fs = new (filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using BufferedStream bs = new(fs, bufferSize);
            byte[] buffer = new byte[bufferSize];
            while (bs.Read(buffer, 0, buffer.Length) > 0)
            {
            }

            sw.Stop();
            Console.WriteLine($"BufferedStream Read ({bufferSize / 1024} KB buffer): {sw.ElapsedMilliseconds} ms");
            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// Processes input string data by converting characters to uppercase.
        /// </summary>
        /// <param name="input">Input text fragment.</param>
        /// <returns>Uppercase converted text.</returns>
        public string ProcessData(string input) => string.IsNullOrEmpty(input) ? string.Empty : input.ToUpperInvariant();

        /// <summary>
        /// Reads, transforms data, buffers output through a MemoryStream chunk, and writes to disk.
        /// </summary>
        /// <param name="inputPath">Source file path.</param>
        /// <param name="outputPath">Destination file path.</param>
        /// <param name="chunkSize">Chunk buffer size in bytes.</param>
        public void ProcessAndWriteLargeFile(string inputPath = SampleFile, string outputPath = OutputFile, int chunkSize = 64 * 1024)
        {
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: {inputPath} does not exist. Generate it first.");
                return;
            }

            Console.WriteLine($"Processing {inputPath} -> {outputPath}...");
            Stopwatch sw = Stopwatch.StartNew();

            using FileStream inputFs = new (inputPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using FileStream outputFs = new (outputPath, FileMode.Create, FileAccess.Write, FileShare.None);

            byte[] readBuffer = new byte[chunkSize];
            int bytesRead;

            while ((bytesRead = inputFs.Read(readBuffer, 0, readBuffer.Length)) > 0)
            {
                string chunkText = Encoding.UTF8.GetString(readBuffer, 0, bytesRead);
                byte[] processedBytes = Encoding.UTF8.GetBytes(this.ProcessData(chunkText));

                using MemoryStream memStream = new (processedBytes.Length);
                memStream.Write(processedBytes, 0, processedBytes.Length);
                memStream.Position = 0;
                memStream.CopyTo(outputFs);
            }

            sw.Stop();
            Console.WriteLine($"Processing completed in {sw.ElapsedMilliseconds} ms.");
        }

        /// <summary>
        /// Demonstrates file generation, benchmark comparison, and MemoryStream file processing.
        /// </summary>
        public void DemonstrateFileDataProcessing()
        {
            bool isFileMenuOpen = true;
            while (isFileMenuOpen)
            {
                Console.Clear();
                Console.Write(@"--- Large File Stream Processor ---

1. Generate 1 GB Sample File (Ignore if already exists)
2. Compare FileStream vs BufferedStream Performance
3. Process Data & Write Output (using MemoryStream)
4. Back to Main Menu

    Select a choice :");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    continue;
                }

                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Press Enter to confirm generation of 1GB file");
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key != ConsoleKey.Enter)
                        {
                            Console.WriteLine("Back to menu...");
                            continue;
                        }

                        this.GenerateSampleFile(SampleFile, 1024);
                        break;
                    case 2:
                        this.ReadFileWithFileStream();
                        this.ReadFileWithBufferedStream();
                        break;
                    case 3:
                        this.ProcessAndWriteLargeFile();
                        break;
                    case 4:
                        isFileMenuOpen = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}