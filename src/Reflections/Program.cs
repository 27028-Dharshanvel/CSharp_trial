namespace Reflections
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args">CMD line args</param>
        public static void Main(string[] args)
        {
            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.WriteLine(@"---------- Reflection in C#  ----------
1.Inspect Assembly Metadata
2.Dynamic Object Inspector
3.Dynamic Method Invoker
4.Dynamic Type Builder
5.Plugin System
6.Mocking Framework
7.Serialization API (Reflection vs Emit)
8.Exit
Select a task to execute (1-8)");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Enter valid integer");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AssemblyInspector.Run();
                        break;
                    case 2:
                        DynamicObjectInspector.Run();
                        break;
                    case 3:
                        DynamicMethodInvoker.Run();
                        break;
                    case 4:
                        DynamicTypeBuilder.Run();
                        break;
                    case 5:
                        PluginSystem.Run();
                        break;
                    case 6:
                        MockingFramework.Run();
                        break;
                    case 7:
                        //TO DO : Serialization API
                        break;
                    case 8:
                        Console.WriteLine("Exiting program. Goodbye!");
                        isAppRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select an option between 1 and 8.");
                        break;
                }
            }
        }
    }
}