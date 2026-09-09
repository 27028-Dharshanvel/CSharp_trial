using Assignment4.Helpers;
using Assignment4.Models;
using Assignment4.Services;

namespace Assignment4.Views
{
    /// <summary>
    /// Main menu class.
    /// </summary>
    internal class MainMenu
    {
        private IUserService _userService;
        private ITransactionService _transactionService;
        private bool _isAppRunning = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu"/> class.
        /// </summary>
        /// <param name="userService">user service</param>
        /// <param name="transactionService">transactionservice</param>
        public MainMenu(IUserService userService, ITransactionService transactionService)
        {
            this._userService = userService;
            this._transactionService = transactionService;
        }

        /// <summary>
        /// Displays Main menu.
        /// </summary>
        public void DisplayMainMenu()
        {
      while (this._isAppRunning)
            {
                Console.WriteLine(@"
================Money manager Application====================

1.Login
2.Create new account
3.Exit");
                int choice = 0;
                if (!InputValidater.IsValidInt("\nEnter your choice : ", "Choice", 1, 4, 3, out choice))
                {
                    choice = (int)MainMenuEnum.Exit;
                }

                MainMenuEnum choiceEnum = (MainMenuEnum)choice;
                switch (choiceEnum)
                {
                    case MainMenuEnum.Login:
                        this.LoginUserHandler();
                        break;

                    case MainMenuEnum.CreateAccount:
                        this.RegisterUserHandler();
                        break;

                    case MainMenuEnum.Exit:
                        Console.WriteLine("Thank you for using Money Manager.");
                        Console.ReadKey();
                        this._isAppRunning = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the logging in of user in Console.
        /// </summary>
        public void LoginUserHandler()
        {
            string? username;
            if (!InputValidater.IsValidString("Username : ", "Username", 15, 3, out username))
            {
                Console.ReadKey();
                this._isAppRunning = false;
                return;
            }

            Guid userId = default(Guid);

            if (this._userService.LoginUser(username, out userId))
            {
                OutputColor.Success($"\nLogin successful! Welcome, {username}.");
                TransactionMenu transactionMenu = new TransactionMenu(this._transactionService, userId);
                transactionMenu.DisplayTransactionMenu();
            }
            else
            {
                OutputColor.Error("Invalid username .");
            }
        }

        /// <summary>
        /// Handles the registering of user in the Console.
        /// </summary>
        public void RegisterUserHandler()
        {
            string? newUserName;
            if (!InputValidater.IsValidString("Username : ", "Username", 15, 3, out newUserName))
            {
                Console.ReadKey();
                this._isAppRunning = false;
                return;
            }

            if (this._userService.RegisterUser(newUserName, out string errorMessage))
            {
                OutputColor.Success("Account created successfully! You can now log in.");
            }
            else
            {
                OutputColor.Error(errorMessage);
            }
        }
    }
}