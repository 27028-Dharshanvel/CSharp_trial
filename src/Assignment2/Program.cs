using Assignment2.BankAccountServices;
using Assignment2.Helpers;
using Assignment2.Models;
using Assignment2.Views;

namespace Assignment2
{
    /// <summary>
    /// Represents program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the program.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(string[] args)
        {
            bool exit = false;
            BankServices bankServices = new BankServices();

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(@"========== Object Oriented Programming ========== 
1. Shape 
2. Employee
3. Bank Account 
4. Exit");

                MainMenu choice = (MainMenu)InputReader.ReadInt("Enter your choice : ", "Choice", 1, 5, 3, -1);

                if ((int)choice == -1)
                {
                    choice = MainMenu.Exit;
                }

                switch (choice)
                {
                    case MainMenu.Shape:
                        ConsoleView.ShowShapeMenu();
                        break;

                    case MainMenu.Employee:
                        ConsoleView.ShowEmployeeMenu();
                        break;

                    case MainMenu.BankAccount:
                        ConsoleView.ShowBankMenu(bankServices);
                        break;

                    case MainMenu.Exit:
                        exit = true;
                        Console.WriteLine("Application exiting");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}