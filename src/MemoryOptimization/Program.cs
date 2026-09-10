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
            MemoryEater me = new MemoryEater();
            OptimizedMemoryEater optim = new OptimizedMemoryEater();
            MainMenu mainMenu = new MainMenu(me, optim);
            mainMenu.DisplayMainMenu();
        }
    }
}