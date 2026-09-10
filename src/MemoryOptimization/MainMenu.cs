using Assignments;

namespace MemoryOptimization
{
    /// <summary>
    /// Main menu
    /// </summary>
    internal class MainMenu
    {
        private MemoryEater _me;
        private OptimizedMemoryEater _optim;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu"/> class.
        /// </summary>
        /// <param name="me">me</param>
        /// <param name="optim">optim</param>
        public MainMenu(MemoryEater me, OptimizedMemoryEater optim) 
        {
            this._me = me;
            this._optim = optim;
        }

        /// <summary>
        /// Displays the main menu.
        /// </summary>
        public void DisplayMainMenu()
        {
            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.WriteLine(@"---------Memory Optimaztion--------------

1.Diagnose memory issues in the code
2.Fix and implement memory management best practices
3.Optimize and compare the corrected code and original code

Choose a task to demonstrate : ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine($"Index: {choice}");
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                switch (choice)
                {
                    case 1:
                        this._me.Allocate();
                        break;

                    case 2:
                        this._optim.Allocate(10000);
                        break;
                    case 3:
                        isAppRunning = false;
                        break;
                }
            }
        }
    }
}
