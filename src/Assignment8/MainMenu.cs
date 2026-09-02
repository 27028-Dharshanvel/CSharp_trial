using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    /// <summary>
    /// MainMenu.
    /// </summary>
    internal class MainMenu
    {
        /// <summary>
        /// Displays main menu.
        /// </summary>
        public static void DisplayMainMenu()
        {
            bool isAppRunning = true;
            while (isAppRunning)
            {
                Console.WriteLine(@"Hello User.... Welcome to Exception Handling
Select your choice to simulate the corresponding Exception : 

1.Simulate Divide a number by zero
2.Simulate accessing an element from array out of its range
3.Simulate invalid user input 
4.Simulate Global unhandled exception
5.Demonstrate StackTrace.");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine($"Index: {choice}");
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                UserOptions userChoice = (UserOptions)choice;

                switch (userChoice)
                {
                    case UserOptions.ExecuteDividebyZeroException:
                        Console.Clear();
                        ExceptionHandlingTasks.DemonstrateDivideByZeroException(10, 0);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case UserOptions.ExecuteIndexOutOfRangeException:
                        Console.Clear();
                        ExceptionHandlingTasks.DemonstrateIndexOutOfRangeException();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case UserOptions.ExecuteInvalidUserInputException:
                        Console.Clear();
                        ExceptionHandlingTasks.DemonstrateInvalidUserInputException();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case UserOptions.ExecuteUnhandledException:
                        Console.Clear();
                        ExceptionHandlingTasks.DemonstrateUnhandledException();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case UserOptions.ExecuteStackTrace:
                        Console.Clear();
                        ExceptionHandlingTasks.DemonstrateStackTrace();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case UserOptions.Exit:
                        isAppRunning = false;
                        break;
                }
            }
        }
    }
}
