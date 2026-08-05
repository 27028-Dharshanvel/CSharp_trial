using System.Drawing;
using System.Runtime.CompilerServices;
using Assignment2.BankAccountModels;
using Assignment2.BankAccountServices;
using Assignment2.Controllers;
using Assignment2.EmployeeModels;
using Assignment2.Helpers;
using Assignment2.Models;
using Assignment2.ShapeModels;

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
            ShapeServices shapeController = new ShapeServices();
            EmployeeServices employeeController = new EmployeeServices();
            BankServices bankController = new BankServices();

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("========== Object Oriented Programming ==========" +
                    "\n1. Shape" +
                    "\n2. Employee" +
                    "\n3. Bank Account" +
                    "\n4. Exit");

                MainMenu choice = (MainMenu)ConsoleHelper.ReadInt("Enter your choice : ", "Choice", 1, 5, 3, 999);

                if ((int)choice == 999)
                {
                    choice = MainMenu.Exit;
                }

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
                        Console.WriteLine("Application exited");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ShowShapeMenu(ShapeServices controller)
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();

                Console.WriteLine("----- Shape Menu -----" +
                    "\n1. Rectangle" +
                    "\n2. Circle" +
                    "\n3. Back");

                ShapeMenu choice = (ShapeMenu)ConsoleHelper.ReadInt("Enter your choice : ", "Choice", 1, 4, 3, -99);
                if ((int)choice == -99)
                {
                    Console.ReadKey();
                    choice = ShapeMenu.Back;
                }

                switch (choice)
                {
                    case ShapeMenu.Rectangle:
                        ShapeModels.Rectangle rect = new ();
                        rect.Length = ConsoleHelper.ReadDouble("Enter the Length : ", "Length", 1, 1000000, 3, -99);
                        if (rect.Length == -99)
                        {
                            Console.ReadKey();
                            break;
                        }

                        rect.Width = ConsoleHelper.ReadDouble("Enter the Width : ", "Width", 1, 1000000, 3, -99);
                        if (rect.Width == -99)
                        {
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine($"\nArea of the rectangle : {rect.CalculateArea()}");
                        Console.ReadKey();
                        break;

                    case ShapeMenu.Circle:
                        ShapeModels.Circle circle = new ();
                        circle.Radius = ConsoleHelper.ReadDouble("Enter the Radius : ", "Radius", 1, 1000000, 3, -99);
                        if (circle.Radius == -99)
                        {
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine($"\nArea of the circle : {circle.CalculateArea()}");
                        Console.ReadKey();
                        break;

                    case ShapeMenu.Back:
                        back = true;
                        break;

                    default:
                        Console.WriteLine("\nInvalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ShowEmployeeMenu(EmployeeServices controller)
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();

                Console.WriteLine("----- Employee Menu -----" +
                    "\n1.Manager" +
                    "\n2.Developer" +
                    "\n3.Back");
                EmployeeMenu choice = (EmployeeMenu)ConsoleHelper.ReadInt("\nEnter your choice : ", "Choice", 1, 4, 3, 999);
                if ((int)choice == 999)
                {
                    Console.ReadKey();
                    choice = EmployeeMenu.Back;
                }

                switch (choice)
                {
                    case EmployeeMenu.Manager:
                        Manager manager = new ();
                        manager.Salary = ConsoleHelper.ReadDecimal("\nEnter your Salary : ", "Salary", 0, 1000000000, 3, -99);
                        if (manager.Salary == -99)
                        {
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine($"\nYour Bonus amount is : {manager.CalculateBonus()}");
                        Console.ReadKey();
                        break;

                    case EmployeeMenu.Developer:
                        Developer developer = new ();
                        developer.Salary = ConsoleHelper.ReadDecimal("Enter your Salary", "Salary", 0, 1000000000, 3, -99);
                        if (developer.Salary == -99)
                        {
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine($"\nYour Bonus amount is : {developer.CalculateBonus()}");
                        Console.ReadKey();
                        break;

                    case EmployeeMenu.Back:
                        back = true;
                        break;

                    default:
                        Console.WriteLine("\nInvalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ShowBankMenu(BankServices controller)
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();

                Console.WriteLine("----- Bank Menu -----" +
                    "\n1.Create Account" +
                    "\n2.View Account Details " +
                    "\n3.Deposit Amount " +
                    "\n4.Withdraw Amount" +
                    "\n5.Back");

                BankMenu choice = (BankMenu)ConsoleHelper.ReadInt("\nEnter your choice : ", "Choice", 1, 6, 3, 999);
                if ((int)choice == 999)
                {
                    Console.ReadKey();
                    choice = BankMenu.Back;
                }

                switch (choice)
                {
                    case BankMenu.CreateAccount:
                        Console.WriteLine("1.Create new Savings Account" +
                            "2.Create new Checking Account");

                    case BankMenu.SavingsAccount:

                        SavingsAccount savingsAccount1 = new ();
                        ConsoleHelper.DisplayBankingOperations();
                        BankingOperationsMenu userChoice = (BankingOperationsMenu)ConsoleHelper.ReadInt("\nEnter the operation to perform :", "Choice", 1, 3, 3, 999);
                        if ((int)choice == 999)
                        {
                            Console.ReadKey();
                            break;
                        }

                        switch (userChoice)
                        {
                            case BankingOperationsMenu.Deposit:

                                savingsAccount1.Deposit(ConsoleHelper.ReadDecimal("\nEnter amount to Deposit :", "Amount", 1, 1000000000, 3, -99));
                                if ((int)choice == -99)
                                {
                                    Console.ReadKey();
                                    break;
                                }
                                Console.WriteLine($"\nAmount Deposited \nCurrent Balance : ${savingsAccount1.AccountBalance}");
                                Console.ReadKey();
                                break;

                            case BankingOperationsMenu.Withdraw:

                                savingsAccount1.Withdraw(ConsoleHelper.ReadDecimal("Enter amount to Withdraw :", "Amount", 1, 1000000000, 3, -99));
                                if ((int)choice == -99)
                                {
                                    Console.ReadKey();
                                    break;
                                }

                                Console.WriteLine($"\nAmount Withdrawn \nCurrent Balance : ${savingsAccount1.AccountBalance}");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    case BankMenu.CheckingAccount:
                        ConsoleHelper.DisplayBankingOperations();
                        CheckingAccount checkingAccount1 = new ();
                        BankingOperationsMenu userChoice2 = (BankingOperationsMenu)ConsoleHelper.ReadInt("\nEnter the operation to perform :", "Choice", 1, 3, 3, 999);
                        if ((int)choice == 999)
                        {
                            Console.ReadKey();
                            break;
                        }

                        switch (userChoice2)
                        {
                            case BankingOperationsMenu.Deposit:

                                checkingAccount1.Deposit(ConsoleHelper.ReadDecimal("\nEnter amount to Deposit : ", "Amount", 1, 1000000000, 3, -99));
                                if ((int)choice == -99)
                                {
                                    Console.ReadKey();
                                    break;
                                }

                                Console.WriteLine($"\nAmount Deposited \nCurrent Balance : ${checkingAccount1.AccountBalance}");
                                Console.ReadKey();
                                break;

                            case BankingOperationsMenu.Withdraw:

                                checkingAccount1.Withdraw(ConsoleHelper.ReadDecimal("Enter amount to Withdraw :", "Amount", 1, 1000000000, 3, -99));
                                if ((int)choice == -99)
                                {
                                    Console.ReadKey();
                                    break;
                                }

                                Console.WriteLine($"\nAmount Withdrawn \nCurrent Balance : ${checkingAccount1.AccountBalance}");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    case BankMenu.Back:
                        back = true;
                        break;

                    default:
                        Console.WriteLine("\nInvalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}