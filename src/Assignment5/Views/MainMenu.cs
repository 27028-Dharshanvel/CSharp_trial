using Assignment5.Helpers;
using Assignment5.Services;

namespace Assignment5.Views
{
    /// <summary>
    /// Main menu class.
    /// </summary>
    internal static class MainMenu
    {
        /// <summary>
        /// Displays Main menu.
        /// </summary>
        /// <param name="userService">userService</param>
        /// <param name="transactionService">transactionService</param>
        public static void DisplayMainMenu(UserService userService, TransactionService transactionService)
        {
            bool isAppRunning = true;

            while (isAppRunning)
            {
                Console.WriteLine(@"
================Money manager Application====================

1.Login
2.Create new account
3.Exit");
                int choice = InputReader.ReadInt("\nEnter your choice : ", "Choice", 1, 4, 3, -1);
                switch (choice)
                {
                    case 1:
                        string username = InputReader.ReadString("Username : ", "Username", 15, 3, "@@@");
                        Guid userId = default(Guid);

                        if (userService.LoginUser(username, out userId))
                        {
                            InputReader.Success($"\nLogin successful! Welcome, {username}.");
                            TransactionMenu.DisplayTransactionMenu(transactionService, userId);
                        }
                        else
                        {
                            InputReader.Error("Invalid username .");
                        }

                        break;

                    case 2:
                        string newUserName = InputReader.ReadString("Enter Username : ", "Username", 15, 3, "@@@");

                        if (userService.RegisterUser(newUserName, out string errorMessage))
                        {
                                InputReader.Success("Account created successfully! You can now log in.");
                        }
                        else
                        {
                                InputReader.Error(errorMessage);
                        }

                        break;

                    case 3:
                        Console.WriteLine("Thank you for using Money Manager. Goodbye!");
                        isAppRunning = false;
                        break;
                }
            }
        }
    }
}