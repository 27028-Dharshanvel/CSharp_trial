using Assignments;

namespace MemoryOptimization
{
    /// <summary>
    /// Main menu 
    /// </summary>
    internal class MainMenu
    {
        /// <summary>
        /// Displays the main menu.
        /// </summary>
        public void DisplayMainMenu()
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
                    MemoryEater me = new MemoryEater();
                    me.Allocate();
                    break;

                case 2:
                    // TO DO : Memory optimization.
                    break;
                case 3:
                    // TO DO : Memory Comparison.
                    break;
            }
        }
    }
}
