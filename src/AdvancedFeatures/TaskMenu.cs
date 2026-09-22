namespace AdvancedFeatures
{
    /// <summary>
    /// Menu for demonstrating tasks
    /// </summary>
    internal class TaskMenu
    {
        /// <summary>
        /// Task demonstration
        /// </summary>
        private TaskDemonstration _taskDemonstration = new TaskDemonstration();

        /// <summary>
        /// Displays the menu
        /// </summary>
        public void DisplayMenu()
        {
            bool isAppRunning = true;
            while (isAppRunning)
            {
                Console.Clear();
                Console.WriteLine(@"------------ Advanced C# Features -------------

1.Demonstrate Events and Delegates
2.Demonstrate dynamic and var keywords
3.Demonstrate anonymous methods
4.Demonstrate Lambda expressions
5.Demonstrate Sort using delegates
6.Demonstrate manipulating records
7.Demonstrate pattern matching

Select a choice : 
");

                if (!InputValidator.IsValidInt(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Enter a valid choice : ");
                    Console.ReadKey();
                    continue;
                }

                if (!InputValidator.IsIntWithinRange(choice, 1, 7))
                {
                    Console.WriteLine("Select a valid choice between 1 - 7 : ");
                    Console.ReadKey();
                    continue;
                }

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        _taskDemonstration.DemonstrateNotificationEvent();
                        break;
                    case 2:
                        _taskDemonstration.DemonstrateVarAndDynamic();
                        break;
                    case 3:
                        _taskDemonstration.DemonstrateAnonymousSort();
                        break;
                    case 4:
                        _taskDemonstration.DemonstrateLambdaExpressions();
                        break;
                    case 5:
                        _taskDemonstration.DemonstrateSortDel();
                        break;
                    case 6:
                        _taskDemonstration.DemonstrateRecords();
                        break;
                    case 7:
                        _taskDemonstration.DemonstratePatternMatching();
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
