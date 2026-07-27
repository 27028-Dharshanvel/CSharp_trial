using System.Drawing;
using System.Runtime.CompilerServices;
using Assignment2.BankAccountModels;
using Assignment2.BankAccountServices;
using Assignment2.Controllers;
using Assignment2.EmployeeModels;
using Assignment2.Helpers;
using Assignment2.Models;

namespace Assignment2
{
    /// <summary>
    /// Represents program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public static void Main(string[] args)
        {
            ShapeController shapeController = new ShapeController();
            EmployeeController employeeController = new EmployeeController();
            BankController bankController = new BankController();

            bool exit = false;

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("========== Object Oriented Programming ==========");
                Console.WriteLine("1. Shape");
                Console.WriteLine("2. Employee");
                Console.WriteLine("3. Bank Account");
                Console.WriteLine("4. Exit");

                Choices.MainMenu choice = (Choices.MainMenu)Helper.ReadInt("Enter your choice : ");

                switch (choice)
                {
                    case Choices.MainMenu.Shape:
                        ShowShapeMenu(shapeController);
                        break;

                    case Choices.MainMenu.Employee:
                        ShowEmployeeMenu(employeeController);
                        break;

                    case Choices.MainMenu.BankAccount:
                        ShowBankMenu(bankController);
                        break;

                    case Choices.MainMenu.Exit:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ShowShapeMenu(ShapeController controller)
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();

                Console.WriteLine("----- Shape Menu -----");
                Console.WriteLine("1. Rectangle");
                Console.WriteLine("2. Circle");
                Console.WriteLine("3. Back");

                Choices.ShapeMenu choice = (Choices.ShapeMenu)Helper.ReadInt("Enter your choice : ");

                switch (choice)
                {
                    case Choices.ShapeMenu.Rectangle:
                        ShapeModels.Rectangle rect = new ();
                        rect.Length = Helper.ReadDouble("Enter the Length :");
                        rect.Width = Helper.ReadDouble("Enter the Width :");
                        Console.WriteLine($"\nArea of the circle :{rect.CalculateArea()}");
                        Console.ReadKey();
                        break;

                    case Choices.ShapeMenu.Circle:
                        ShapeModels.Circle circle = new ();
                        circle.Radius = Helper.ReadDouble("Enter the Radius :");
                        Console.WriteLine($"\nArea of the circle :{circle.CalculateArea()}");
                        Console.ReadKey();
                        break;

                    case Choices.ShapeMenu.Back:
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ShowEmployeeMenu(EmployeeController controller)
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();

                Console.WriteLine("----- Employee Menu -----");
                Console.WriteLine("1. Manager");
                Console.WriteLine("2. Developer");
                Console.WriteLine("3. Back");

                Choices.EmployeeMenu choice = (Choices.EmployeeMenu)Helper.ReadInt("Enter your choice : ");

                switch (choice)
                {
                    case Choices.EmployeeMenu.Manager:
                        Manager manager = new ();
                        manager.Salary = Helper.ReadInt("Enter your Salary");
                        Console.WriteLine($"Your Bonus amount is : {manager.CalculateBonus()}");
                        Console.ReadKey();
                        break;

                    case Choices.EmployeeMenu.Developer:
                        Developer developer = new ();
                        developer.Salary = Helper.ReadInt("Enter your Salary");
                        Console.WriteLine($"Your Bonus amount is : {developer.CalculateBonus()}");
                        Console.ReadKey();
                        break;

                    case Choices.EmployeeMenu.Back:
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ShowBankMenu(BankController controller)
        {
            bool back = false;
            bool isBankRunning = false;

            while (!back)
            {
                Console.Clear();

                Console.WriteLine("----- Bank Menu -----\n\n1. Savings account \n2.Checking account \n3.Back");

                Choices.BankMenu choice = (Choices.BankMenu)Helper.ReadInt("Enter your choice : ");

                switch (choice)
                {
                    case Choices.BankMenu.SavingsAccount:

                        SavingsAccount savingsAccount1 = new ();
                        Helper.DisplayBankingOperations();
                        Choices.BankingOperations userChoice = (Choices.BankingOperations)Helper.ReadInt("Enter the operation to perform :");
                        switch (userChoice)
                        {
                            case Choices.BankingOperations.Deposit:

                                savingsAccount1.Deposit(Helper.ReadInt("Enter amount to Deposit :"));
                                Console.WriteLine($"Amount Deposited \nCurrent Balance : ${savingsAccount1.AccountBalance}");
                                Console.ReadKey();
                                break;

                            case Choices.BankingOperations.Withdraw:

                                savingsAccount1.Withdraw(Helper.ReadInt("Enter amount to Withdraw :"));
                                Console.WriteLine($"Amount Withdrawn \nCurrent Balance : ${savingsAccount1.AccountBalance}");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    case Choices.BankMenu.CheckingAccount:
                        Helper.DisplayBankingOperations();
                        CheckingAccount checkingAccount1 = new ();
                        Choices.BankingOperations userChoice2 = (Choices.BankingOperations)Helper.ReadInt("Enter the operation to perform :");
                        switch (userChoice2)
                        {
                            case Choices.BankingOperations.Deposit:

                                checkingAccount1.Deposit(Helper.ReadInt("Enter amount to Deposit : "));
                                Console.WriteLine($"Amount Deposited \nCurrent Balance : ${checkingAccount1.AccountBalance}");
                                Console.ReadKey();
                                break;

                            case Choices.BankingOperations.Withdraw:

                                checkingAccount1.Withdraw(Helper.ReadInt("Enter amount to Withdraw :"));
                                Console.WriteLine($"Amount Withdrawn \nCurrent Balance : ${checkingAccount1.AccountBalance}");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    case Choices.BankMenu.Back:
                        back = true;
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