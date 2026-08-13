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
            UserListRepository userListRepository = new UserListRepository();
            UserService userService = new UserService(userListRepository);
            TransactionListRepository transactionListRepository = new TransactionListRepository();
            TransactionService transactionService = new TransactionService(transactionListRepository);
            MainMenu.DisplayMainMenu(userService, transactionService);
        }
    }
}