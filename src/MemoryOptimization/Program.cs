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
                Console.Clear();
                Console.WriteLine(@"---------Memory Optimization--------------

1.Diagnose memory issues in the memory consuming code 
2.Fix and implement memory management best practices
3.Exit

Choose a task to demonstrate : ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Enter a valid choice");
                    continue;
                }

                if (!InputValidator.IsIntWithinRange(choice, 1, 3))
                {
                    Console.WriteLine("Select a choice between 1-3");
                    continue;
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
                            optimizedMemoryEater.Allocate(10000);
                        }

                        break;
                    case 3:
                        isAppRunning = false;
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}