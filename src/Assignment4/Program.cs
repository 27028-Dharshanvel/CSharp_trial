using System.Globalization;
using Assignment4.Repository;
using Assignment4.Services;
using Assignment4.Views;

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
            IUserRepository userPersistenceRepository = new UserPersistenceRepository();
            IUserService userService = new UserService(userPersistenceRepository);
            ITransactionRepository transactionPersistenceRepository = new TransactionPersistenceRepository();
            ITransactionService transactionService = new TransactionService(transactionPersistenceRepository);
            MainMenu mainMenu = new MainMenu(userService, transactionService);
            mainMenu.DisplayMainMenu();
        }
    }
}