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
            IUserRepository userListRepository = new UserListRepository();
            UserService userService = new UserService(userListRepository);
            ITransactionRepository transactionListRepository = new TransactionListRepository();
            TransactionService transactionService = new TransactionService(transactionListRepository);
            MainMenu.DisplayMainMenu(userService, transactionService);
        }
    }
}