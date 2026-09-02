using LanguageInetgratedQuery;
using LanguageInetgratedQuery.Models;

namespace Assignments
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">cmd args</param>
        public static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.DisplayMainMenu();
        }
    }
}