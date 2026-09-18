using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileStreams
{
    /// <summary>
    /// Task 4 runner and performance load testing suite.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Subtask 5: Load testing to simulate multiple users logging errors simultaneously.
        /// </summary>
        /// <param name="userCount">Number of concurrent user threads.</param>
        /// <param name="logsPerUser">Number of log messages per user.</param>
        public static void RunLoadTest(int userCount = 10, int logsPerUser = 50)
        {
            Console.WriteLine($"\n[Task 4] Running Load Test with {userCount} concurrent users ({logsPerUser} logs each)...");

            // 1. Test Initial Logger under concurrent load
            Stopwatch swInitial = Stopwatch.StartNew();
            Parallel.For(0, userCount, userId =>
            {
                for (int j = 0; j < logsPerUser; j++)
                {
                    LoggerInitial.LogError($"User {userId} error message #{j}");
                }
            });
            swInitial.Stop();
            Console.WriteLine($"[Task 4 Load Test] Initial Logger completed in: {swInitial.ElapsedMilliseconds} ms (with potential locked file drop errors)");

            // 2. Test Improved Single-File Logger (Thread-Safe)
            Stopwatch swImproved = Stopwatch.StartNew();
            Parallel.For(0, userCount, userId =>
            {
                for (int j = 0; j < logsPerUser; j++)
                {
                    LoggerImproved.LogError($"User {userId} error message #{j}");
                }
            });
            swImproved.Stop();
            Console.WriteLine($"[Task 4 Load Test] Improved Thread-Safe Logger completed in: {swImproved.ElapsedMilliseconds} ms (0 errors)");

            // 3. Test Independent User File Logger
            Stopwatch swUserFiles = Stopwatch.StartNew();
            Parallel.For(0, userCount, userId =>
            {
                for (int j = 0; j < logsPerUser; j++)
                {
                    LoggerImproved.LogUserError($"User_{userId}", $"error message #{j}");
                }
            });
            swUserFiles.Stop();
            Console.WriteLine($"[Task 4 Load Test] Independent User Log Files completed in: {swUserFiles.ElapsedMilliseconds} ms (0 errors)");
        }

        /// <summary>
        /// Subtask 1 Analysis display.
        /// </summary>
        public static void PrintSubtask1Analysis()
        {
            Console.WriteLine(" Task 4: Subtask 1 - Identification of Issues         ");
            Console.WriteLine(@"
1. Inefficient Memory Usage:
   - Creating a new MemoryStream for every single log operation allocates heap memory unnecessarily.
   - Encoding error bytes and copying them from MemoryStream to FileStream produces GC pressure under high logging volume.

2. File Access Concurrency & Race Conditions:
   - Multiple threads calling LogError simultaneously try to open `log.txt` in FileMode.Append without synchronization.
   - FileStream attempts to lock the disk file exclusively. Concurrent attempts throw IOException:
     'The process cannot access the file because it is being used by another process.'
");
        }

        /// <summary>
        /// Runs complete Task 4 demonstration.
        /// </summary>
        public static void RunDemo()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("   Task 4: Logger System & Load Testing   ");
            Console.WriteLine("==========================================");

            PrintSubtask1Analysis();
            RunLoadTest();

            Console.WriteLine("[Task 4 Demo Complete]\n");
        }
    }

    /// <summary>
    /// Initial Logger implementation provided in starter code (Task 4).
    /// Suffers from MemoryStream allocations and concurrency contention errors.
    /// </summary>
    public class LoggerInitial
    {
        private static string logFilePath = "log_initial.txt";

        /// <summary>
        /// Logs error using MemoryStream and un-synchronized FileStream write.
        /// </summary>
        /// <param name="errorMessage">Error message string.</param>
        public static void LogError(string errorMessage)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage + Environment.NewLine);
                    memoryStream.Write(errorBytes, 0, errorBytes.Length);
                    using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write))
                    {
                        memoryStream.WriteTo(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                // Silence file lock race condition exceptions during high-concurrency test
                _ = ex.Message;
            }
        }
    }

    /// <summary>
    /// Improved Logger addressing Subtasks 2, 3, and 4.
    /// </summary>
    public class LoggerImproved
    {
        private static readonly object LockObj = new object();
        private static string logFilePath = "log_improved.txt";

        /// <summary>
        /// Subtask 2 & 3: Direct file writing with thread-safe locking mechanism.
        /// </summary>
        /// <param name="errorMessage">Error message text.</param>
        public static void LogError(string errorMessage)
        {
            byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage + Environment.NewLine);

            lock (LockObj)
            {
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                {
                    fileStream.Write(errorBytes, 0, errorBytes.Length);
                }
            }
        }

        /// <summary>
        /// Subtask 4: Independent error files per user to eliminate single-file lock contention.
        /// </summary>
        /// <param name="userId">User identifier.</param>
        /// <param name="errorMessage">Error message text.</param>
        public static void LogUserError(string userId, string errorMessage)
        {
            string userLogPath = $"log_user_{userId}.txt";
            byte[] errorBytes = Encoding.UTF8.GetBytes($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] User {userId}: {errorMessage}{Environment.NewLine}");

            // Write directly to user-specific file
            using (FileStream fileStream = new FileStream(userLogPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                fileStream.Write(errorBytes, 0, errorBytes.Length);
            }
        }
    }
}