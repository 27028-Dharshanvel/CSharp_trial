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
                Console.Clear();
                switch (userChoice)
                {
                    case UserOptions.ExecuteDividebyZeroException:

                        ExceptionHandlingTask.DemonstrateDivideByZeroException(10, 0);
                        break;
                    case UserOptions.ExecuteIndexOutOfRangeException:
                        ExceptionHandlingTask.DemonstrateIndexOutOfRangeException();
                        break;
                    case UserOptions.ExecuteInvalidUserInputException:
                        ExceptionHandlingTask.DemonstrateInvalidUserInputException();
                        break;
                    case UserOptions.ExecuteUnhandledException:
                        ExceptionHandlingTask.DemonstrateUnhandledException();
                        break;
                    case UserOptions.ExecuteStackTrace:
                        ExceptionHandlingTask.DemonstrateStackTrace();
                        break;
                    case UserOptions.Exit:
                        isAppRunning = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
