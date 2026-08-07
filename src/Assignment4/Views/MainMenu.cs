using System;
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
        public static void DisplayMainMenu()
        {
            UserService userService = new UserService();
            bool running = true;

            while (running)
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
                        Console.Write("Username : ");
                        string? username = Console.ReadLine();
                        Console.Write("Password : ");
                        string? password = Console.ReadLine();

                        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) &&
                            userService.LoginUser(username, password, out User? user) && user != null)
                        {
                            InputReader.Success($"\nLogin successful! Welcome, {user.UserName}.");
                            TransactionMenu.DisplayTransactionMenu();
                        }
                        else
                        {
                            InputReader.Error("Invalid username or password.");
                        }

                        break;

                    case 2:
                        Console.Write("Enter your username : ");
                        string? newUsername = Console.ReadLine();
                        Console.Write("Enter your password : ");
                        string? newPassword = Console.ReadLine();

                        if (!string.IsNullOrEmpty(newUsername) && !string.IsNullOrEmpty(newPassword))
                        {
                            if (userService.RegisterUser(newUsername, newPassword, out string errorMessage))
                            {
                                InputReader.Success("Account created successfully! You can now log in.");
                            }
                            else
                            {
                                InputReader.Error(errorMessage);
                            }
                        }
                        else
                        {
                            InputReader.Error("Username and password cannot be empty.");
                        }

                        break;

                    case 3:
                        Console.WriteLine("Thank you for using Money Manager. Goodbye!");
                        running = false;
                        break;
                }
            }
        }
    }
}