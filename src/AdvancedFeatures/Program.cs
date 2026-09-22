using AdvancedFeatures;

namespace Assignments
{
    /// <summary>
    /// Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args">CMD Line </param>
        public static void Main(string[] args)
        {
            TaskMenu taskMenu = new TaskMenu();
            taskMenu.DisplayMenu();
        }
    }
}