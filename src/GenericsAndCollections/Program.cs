using System.Reflection.Metadata.Ecma335;
using GenericsAndCollections;

namespace Assignments
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            GenericsAndCollection collection =
                new GenericsAndCollection();

            bool isAppRunning = true;
            while (isAppRunning)
            {
                Console.Clear();
                Console.Write(@"------------ Generics and Collections -------------

1.Demonstration of List
2.Demonstration of Stack
3.Demonstration of Queue
4.Demonstration of Dictionary
5.Demonstration of IEnumerable and ReadOnlyDictionary
6.Exit

Enter a choice : ");

                if (!InputValidator.IsValidInt(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Enter a valid choice : ");
                    Console.ReadKey();
                    continue;
                }

                if (!InputValidator.IsIntWithinRange(choice, 1, 6))
                {
                    Console.WriteLine("Enter a choice between 1-6");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        collection.DemonstrateList();
                        break;
                    case 2:
                        collection.DemonstrateStack("Dharshan");
                        break;
                    case 3:
                        collection.DemonstrateQueue();
                        break;
                    case 4:
                        collection.DemonstrateDictionary();
                        break;
                    case 5:
                        collection.DemonstrateIEnumerable();
                        collection.DemonstrateReadOnlyDictionary();
                        break;
                    case 6:
                        isAppRunning = false;
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}