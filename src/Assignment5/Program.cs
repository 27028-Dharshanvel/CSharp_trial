using Assignment5.Repository;
using Assignment5.Services;
using Assignment5.Views;

namespace Assignments
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the program.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public static void Main(string[] args)
        {
            UserPersistenceRepository userRepository = new UserPersistenceRepository();
            UserService userService = new UserService(userRepository);
            TransactionPersistenceRepository transactionRepository = new TransactionPersistenceRepository();
            TransactionService transactionService = new TransactionService(transactionRepository);
            MainMenu.DisplayMainMenu(userService, transactionService);
        }
    }
}