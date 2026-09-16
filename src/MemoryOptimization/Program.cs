using MemoryOptimization;

namespace Assignments
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the program.
        /// </summary>
        /// <param name="args">CMD line args</param>
        public static void Main(string[] args)
        {
            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.WriteLine(@"---------Memory Optimaztion--------------

1.Diagnose memory issues in the code
2.Fix and implement memory management best practices
3.Exit

Choose a task to demonstrate : ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input");
                }

                switch (choice)
                {
                    case 1:
                        MemoryEater memoryEater = new MemoryEater();
                        memoryEater.Allocate();
                        break;

                    case 2:
                        using (OptimizedMemoryEater optimizedMemoryEater = new OptimizedMemoryEater())
                        {
                            Task.Run(() => optimizedMemoryEater.Allocate(1000));
                        }

                        break;
                    case 3:
                        isAppRunning = false;
                        break;
                }
            }
        }
    }
}