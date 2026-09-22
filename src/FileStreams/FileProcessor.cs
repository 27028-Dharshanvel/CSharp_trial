using System.Diagnostics;
using System.Text;

namespace FileStreams
{
    /// <summary>
    /// File processing with FileStream, MemoryStream, and Stream-based chunking
    /// </summary>
    public class FileProcessor
    {
        private string _sampleFile = "SampleFile.txt";
        private string _outputFile = "OutputFile.txt";

        /// <summary>
        /// Generates a sample text file of a specified size in megabytes.
        /// </summary>
        /// <param name="filePath">filepath</param>
        /// <param name="sizeInMb">size in megabytes</param>
        public void GenerateSampleFile(string filePath, int sizeInMb)
        {
            try
            {
                Console.WriteLine($"Generating sample file of size {sizeInMb} MB at: {filePath}");
                long targetBytes = (long)sizeInMb * 1024 * 1024;
                string sampleLine = @"This is a sample text to write on a file : The text could be repetitive , written only for demonstration purpose.
";
                byte[] lineBytes = Encoding.UTF8.GetBytes(sampleLine);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    long written = 0;
                    while (written < targetBytes)
                    {
                        fileStream.Write(lineBytes, 0, lineBytes.Length);
                        written += lineBytes.Length;
                    }
                }

                Console.WriteLine("Sample file generation completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating sample file: {ex.Message}");
            }
        }

        /// <summary>
        /// Reads a file in chunks using standard FileStream and measures performance.
        /// </summary>
        /// <param name="filePath">filepath</param>
        /// <param name="bufferSize">buffersize</param>
        /// <returns>long</returns>
        public long ReadFileWithFileStream(string filePath, int bufferSize = 64 * 1024)
        {
            try
            {
                Console.WriteLine($"Reading with FileStream (Buffer: {bufferSize / 1024} KB)...");
                Stopwatch stopwatch = Stopwatch.StartNew();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize))
                {
                    byte[] buffer = new byte[bufferSize];
                    int bytesRead;
                    long totalBytesRead = 0;

                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        totalBytesRead += bytesRead;
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($"FileStream read completed. Time: {stopwatch.ElapsedMilliseconds} ms");
                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FileStream read error: {ex.Message}");
                return -1;
            }
        }

        /// <summary>
        /// Reads a file using BufferedStream wrapping a FileStream and measures performance.
        /// </summary>
        /// <param name="filePath">filepath</param>
        /// <param name="bufferSize">buffersize</param>
        /// <returns>long</returns>
        public long ReadFileWithBufferedStream(string filePath, int bufferSize = 64 * 1024)
        {
            try
            {
                Console.WriteLine($"Reading with BufferedStream (Buffer: {bufferSize / 1024} KB)...");
                Stopwatch stopwatch = Stopwatch.StartNew();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (BufferedStream bufferedStream = new BufferedStream(fileStream, bufferSize))
                {
                    byte[] buffer = new byte[bufferSize];
                    int bytesRead;
                    long totalBytesRead = 0;

                    while ((bytesRead = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        totalBytesRead += bytesRead;
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($"BufferedStream read completed. Time: {stopwatch.ElapsedMilliseconds} ms");
                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"BufferedStream read error: {ex.Message}");
                return -1;
            }
        }

        /// <summary>
        /// Processes string data by converting all text to uppercase.
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>string</returns>
        public string ProcessData(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            return input.ToUpperInvariant();
        }

        /// <summary>
        /// Processes and outputs text in Uppercase and in small chunks to prevent high memory usage.
        /// </summary>
        /// <param name="inputPath">inputpath</param>
        /// <param name="outputPath">outpath</param>
        /// <param name="bufferSize">buffersize</param>
        public void ProcessAndWriteLargeFile(string inputPath, string outputPath, int bufferSize = 64 * 1024)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Console.WriteLine($"Streaming and transforming data from {inputPath} to {outputPath} in chunks...");

                using (FileStream fsInput = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (StreamReader reader = new StreamReader(fsInput, Encoding.UTF8))

                using (FileStream fsOutput = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
                using (StreamWriter writer = new StreamWriter(fsOutput, Encoding.UTF8))
                {
                    char[] buffer = new char[bufferSize];
                    int charsRead;

                    while ((charsRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        string chunkText = new string(buffer, 0, charsRead);
                        string processedChunk = ProcessData(chunkText);

                        writer.Write(processedChunk);
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($@"Large file streaming and processing completed successfully.
Time taken for the read and write process : {stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Streaming error: {ex.Message}");
            }
        }

        /// <summary>
        /// Runs a complete demonstration.
        /// </summary>
        public void DeomstrateFileDataProcessing()
        {
            Console.WriteLine(@" File Data Processor Demonstration 
1.If running for first time, generate a sample text file for 1GB . (Ignore if already generated) 
2.Read the file using Filestream and BufferedStream and compare the performance:
4.Read the file and convert all text to uppercase and write to file using memorystream");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice");
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Confirm to generate a file for 1GB.");
                    Console.ReadKey();
                    this.GenerateSampleFile(this._sampleFile, 1024);
                    break;
                case 2:
                    Console.WriteLine("Demonstration of reading a file using Filestream:");
                    long fileStreamTime = this.ReadFileWithFileStream(this._sampleFile);
                    Console.WriteLine($"FileStream: {fileStreamTime} ms ");

                    Console.WriteLine("\nDemonstration of reading a file using bufferedstream:");
                    long bufferedStreamTime = this.ReadFileWithBufferedStream(this._sampleFile);
                    Console.WriteLine($"BufferedStream: {bufferedStreamTime} ms");
                    break;
                case 3:
                    break;
                case 4:
                    Console.WriteLine("Demostration of file reading and process data and write to a new file using MemoryStream");
                    if (File.Exists(this._sampleFile))
                    {
                        this.ProcessAndWriteLargeFile(this._sampleFile, this._outputFile);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {this._sampleFile} not found. Please run Option 1 first to generate it.");
                    }

                    break;
            }

            Console.ReadKey();
        }
    }
}
