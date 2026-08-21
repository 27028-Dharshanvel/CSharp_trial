using Assignment4.Helpers;
using Assignment4.Models;
using Assignment4.Services;

namespace Assignment4.Views
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
                int choice = 0;
                if (!InputReader.ReadInt("\nEnter your choice : ", "Choice", 1, 4, 3, out choice))
                {
                    choice = (int)MainMenuEnum.Exit;
                }

                MainMenuEnum choiceEnum = (MainMenuEnum)choice;
                switch (choiceEnum)
                {
                    case MainMenuEnum.Login:
                        string? username;
                        if (!InputReader.ReadString("Username : ", "Username", 15, 3, out username))
                        {
                            Console.ReadKey();
                            isAppRunning = false;
                            break;
                        }

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

                    case MainMenuEnum.CreateAccount:
                        string? newUserName;
                        if (!InputReader.ReadString("Username : ", "Username", 15, 3, out newUserName))
                        {
                            Console.ReadKey();
                            isAppRunning = false;
                            break;
                        }
                        if (userService.RegisterUser(newUserName, out string errorMessage))
                        {
                                InputReader.Success("Account created successfully! You can now log in.");
                        }
                        else
                        {
                                InputReader.Error(errorMessage);
                        }

                        break;

                    case MainMenuEnum.Exit:
                        Console.WriteLine("Thank you for using Money Manager.");
                        Console.ReadKey();
                        isAppRunning = false;
                        break;
                }
            }
        }
    }
}