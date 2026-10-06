namespace AsyncProgramming
{
    /// <summary>
    /// MainMenu class
    /// </summary>
    internal class MainMenu
    {
        /// <summary>
        /// Displays the main menu and handles user selection asynchronously.
        /// </summary>
        /// <returns>Task representing the asynchronous operation.</returns>
        public static async Task DisplayMainMenu()
        {
            bool isAppRunning = true;
            while (isAppRunning)
            {
                Console.Clear();
                Console.WriteLine(@"------------- Asynchronous Programming --------------

1.Download a HttpClient class
2.Understand Task parallel library
3.Understand multithreading
4.Multi layered async/await operations
5.Debugging DeadLock
6.Application of configureAwait with thread tracking
7.Difference between async task and async void with exceptions
8.Exit Application");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Enter valid integer");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        await AsyncTaskDemonstration.TaskOne();
                        break;

                    case 2:
                        AsyncTaskDemonstration.TaskTwo();
                        break;

                    case 3:
                        AsyncTaskDemonstration.TaskThree();
                        break;

                    case 4:
                        await AsyncTaskDemonstration.TaskFour();
                        break;

                    case 5:
                        await AsyncTaskDemonstration.TaskFive();
                        break;

                    case 6:
                        await AsyncTaskDemonstration.TaskSix();
                        break;

                    case 7:
                        await AsyncTaskDemonstration.TaskSeven();
                        break;

                    case 8:
                        isAppRunning = false;
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}