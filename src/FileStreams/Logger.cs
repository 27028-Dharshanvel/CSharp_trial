using System.Diagnostics;
using System.Text;

/// <summary>
/// Logger class
/// </summary>
public class Logger
{
    private static readonly object _lock = new object();

    /// <summary>
    /// Logs an error using the original implementation.
    /// </summary>
    /// <param name="errorMessage">The error message to log.</param>
    public static void LogError(string errorMessage)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
            memoryStream.Write(errorBytes, 0, errorBytes.Length);

            using (FileStream fileStream = new FileStream(
                "log.txt",
                FileMode.Append))
            {
                memoryStream.WriteTo(fileStream);
            }
        }
    }

    /// <summary>
    /// Logs an error directly to a unique file for each user.
    /// </summary>
    /// <param name="userId">ID of the user.</param>
    /// <param name="errorMessage">error message to log.</param>
    public static void OptimizedLogError(string userId, string errorMessage)
    {
        string filePath = $"log_{userId}.txt";

        lock (_lock)
        {
            using (FileStream fileStream = new FileStream(
                filePath,
                FileMode.Append))
            {
                byte[] errorBytes =
                    Encoding.UTF8.GetBytes(errorMessage + Environment.NewLine);

                fileStream.Write(errorBytes, 0, errorBytes.Length);
            }
        }
    }

    /// <summary>
    /// Compares the performance of the original and improved logging methods.
    /// </summary>
    public static void PerformanceTest()
    {
        int userCount = 100;
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        Task[] oldTasks = new Task[userCount];

        for (int i = 0; i < userCount; i++)
        {
            int userId = i;

            oldTasks[i] = Task.Run(() =>
            {
                LogError("Error from user " + userId);
            });
        }

        Task.WaitAll(oldTasks);

        stopwatch.Stop();

        Console.WriteLine(
            "Original: " + stopwatch.ElapsedMilliseconds + " ms");

        stopwatch.Restart();

        Task[] newTasks = new Task[userCount];

        for (int i = 0; i < userCount; i++)
        {
            int userId = i;

            newTasks[i] = Task.Run(() =>
            {
                OptimizedLogError(
                    userId.ToString(),
                    "Error from user " + userId);
            });
        }

        Task.WaitAll(newTasks);

        stopwatch.Stop();

        Console.WriteLine(
            "Improved: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}