using System.Text;

/// <summary>
/// Basic File usage
/// </summary>
public class BasicFileUsage
{
    /// <summary>
    /// Demonstrates both the original inefficient file I/O operations.
    /// </summary>
    public static void DemonstrateFileUsage()
    {
        Console.WriteLine("=== Original Basic File Usage (Inefficient) ===");
        RunOriginalCode();

        Console.WriteLine("\n=== Improved Basic File Usage (Memory Efficient) ===");
        RunImprovedCode();
    }

    /// <summary>
    /// Original Starter Code (Exhibiting Memory Inefficiencies and Byte-level Casting)
    /// </summary>
    private static void RunOriginalCode()
    {
        string path = "original_test.txt";
        string data = "This is some test data";

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
    /// Fixed Implementation (Eliminates MemoryStream, eliminates heap allocations, uses StreamReader/Writer)
    /// </summary>
    private static void RunImprovedCode()
    {
        string path = "improved_test.txt";
        string data = "This is some test data";

        using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
        {
            writer.Write(data);
        }

        using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}