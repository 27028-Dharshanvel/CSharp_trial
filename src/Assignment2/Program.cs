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

                Console.WriteLine("========== Object Oriented Programming ==========" +
                    "\n1. Shape" +
                    "\n2. Employee" +
                    "\n3. Bank Account" +
                    "\n4. Exit");

                MainMenu choice = (MainMenu)Helper.ReadInt("Enter your choice : ");

                switch (choice)
                {
                    case MainMenu.Shape:
                        ShowShapeMenu(shapeController);
                        break;

                    case MainMenu.Employee:
                        ShowEmployeeMenu(employeeController);
                        break;

                    case MainMenu.BankAccount:
                        ShowBankMenu(bankController);
                        break;

                    case MainMenu.Exit:
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

                Console.WriteLine("----- Shape Menu -----" + "\n1. Recatnagle" + "\n2. Circle" + "\n3. Back");

                ShapeMenu choice = (ShapeMenu)Helper.ReadInt("Enter your choice : ");

                switch (choice)
                {
                    case ShapeMenu.Rectangle:
                        ShapeModels.Rectangle rect = new ();
                        rect.Length = Helper.ReadDouble("Enter the Length :");
                        rect.Width = Helper.ReadDouble("Enter the Width :");
                        Console.WriteLine($"\nArea of the rectangle :{rect.CalculateArea()}");
                        Console.ReadKey();
                        break;

                    case ShapeMenu.Circle:
                        ShapeModels.Circle circle = new ();
                        circle.Radius = Helper.ReadDouble("Enter the Radius :");
                        Console.WriteLine($"\nArea of the circle :{circle.CalculateArea()}");
                        Console.ReadKey();
                        break;

                    case ShapeMenu.Back:
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

                Console.WriteLine("----- Employee Menu -----" +
                    "\n1. Manager" +
                    "\n2.Developer" +
                    "\n3.Back");
                EmployeeMenu choice = (EmployeeMenu)Helper.ReadInt("Enter your choice : ");

                switch (choice)
                {
                    case EmployeeMenu.Manager:
                        Manager manager = new ();
                        manager.Salary = Helper.ReadInt("Enter your Salary");
                        Console.WriteLine($"Your Bonus amount is : {manager.CalculateBonus()}");
                        Console.ReadKey();
                        break;

                    case EmployeeMenu.Developer:
                        Developer developer = new ();
                        developer.Salary = Helper.ReadInt("Enter your Salary");
                        Console.WriteLine($"Your Bonus amount is : {developer.CalculateBonus()}");
                        Console.ReadKey();
                        break;

                    case EmployeeMenu.Back:
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

                BankMenu choice = (BankMenu)Helper.ReadInt("Enter your choice : ");

                switch (choice)
                {
                    case BankMenu.SavingsAccount:

                        SavingsAccount savingsAccount1 = new ();
                        Helper.DisplayBankingOperations();
                        BankingOperationsMenu userChoice = (BankingOperationsMenu)Helper.ReadInt("Enter the operation to perform :");
                        switch (userChoice)
                        {
                            case BankingOperationsMenu.Deposit:

                                savingsAccount1.Deposit(Helper.ReadInt("Enter amount to Deposit :"));
                                Console.WriteLine($"Amount Deposited \nCurrent Balance : ${savingsAccount1.AccountBalance}");
                                Console.ReadKey();
                                break;

                            case BankingOperationsMenu.Withdraw:

                                savingsAccount1.Withdraw(Helper.ReadInt("Enter amount to Withdraw :"));
                                Console.WriteLine($"Amount Withdrawn \nCurrent Balance : ${savingsAccount1.AccountBalance}");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    case BankMenu.CheckingAccount:
                        Helper.DisplayBankingOperations();
                        CheckingAccount checkingAccount1 = new ();
                        BankingOperationsMenu userChoice2 = (BankingOperationsMenu)Helper.ReadInt("Enter the operation to perform :");
                        switch (userChoice2)
                        {
                            case BankingOperationsMenu.Deposit:

                                checkingAccount1.Deposit(Helper.ReadInt("Enter amount to Deposit : "));
                                Console.WriteLine($"Amount Deposited \nCurrent Balance : ${checkingAccount1.AccountBalance}");
                                Console.ReadKey();
                                break;

                            case BankingOperationsMenu.Withdraw:

                                checkingAccount1.Withdraw(Helper.ReadInt("Enter amount to Withdraw :"));
                                Console.WriteLine($"Amount Withdrawn \nCurrent Balance : ${checkingAccount1.AccountBalance}");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    case BankMenu.Back:
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