using System.Drawing;
using System.Runtime.CompilerServices;
using Assignment2.BankAccountModels;
using Assignment2.BankAccountServices;
using Assignment2.Controllers;
using Assignment2.EmployeeModels;
using Assignment2.Helpers;
using Assignment2.Models;
using Assignment2.Models.Menus;
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
                    "\n2.View Account Details" +
                    "\n3.Deposit Amount" +
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
                        Console.WriteLine("\n--- Create Account ---" +
                            "\n1. Savings Account" +
                            "\n2. Checking Account");
                        BankAccountTypeMenu accountTypeChoice = (BankAccountTypeMenu)ConsoleHelper.ReadInt("Select Account Type : ", "Choice", 1, 3, 3, 999);
                        if ((int)accountTypeChoice == 999)
                        {
                            Console.ReadKey();
                            break;
                        }

                        string name = ConsoleHelper.ReadString("Enter Account Holder Name : ", "Account Holder Name", 30, 3, "@@@");
                        if (name == "@@@")
                        {
                            Console.ReadKey();
                            break;
                        }

                        if (accountTypeChoice == BankAccountTypeMenu.SavingsAccount)
                        {
                            decimal initialDeposit = ConsoleHelper.ReadDecimal($"Enter Initial Deposit : ", "Initial Deposit", 1, 1000000000, 3, -99);
                            if (initialDeposit == -99)
                            {
                                Console.ReadKey();
                                break;
                            }

                            SavingsAccount savingsAccount = new SavingsAccount
                            {
                                AccountHolder = name,
                                AccountBalance = initialDeposit,
                            };

                            if (initialDeposit < savingsAccount.MinimumBalance)
                            {
                                ConsoleHelper.Error($"Initial deposit must be at least ${savingsAccount.MinimumBalance} for a Savings Account.");
                                Console.ReadKey();
                                break;
                            }

                            controller.CreateAccount(savingsAccount);
                            Console.WriteLine($"\nSavings Account Created Successfully!\nAccount Number : {savingsAccount.AccountNumber}\nAccount Balance : ${savingsAccount.AccountBalance}");
                            Console.ReadKey();
                        }
                        else if (accountTypeChoice == BankAccountTypeMenu.CheckingAccount)
                        {
                            decimal initialDeposit = ConsoleHelper.ReadDecimal("Enter Initial Deposit : ", "Initial Deposit", 0, 1000000000, 3, -99);
                            if (initialDeposit == -99)
                            {
                                Console.ReadKey();
                                break;
                            }

                            CheckingAccount checkingAccount = new CheckingAccount
                            {
                                AccountHolder = name,
                                AccountBalance = initialDeposit,
                            };

                            controller.CreateAccount(checkingAccount);
                            Console.WriteLine($"\nChecking Account Created Successfully!\nAccount Number : {checkingAccount.AccountNumber}\nAccount Balance : ${checkingAccount.AccountBalance}");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Account Type.");
                            Console.ReadKey();
                        }

                        break;

                    case BankMenu.ViewAccountDetails:
                        Console.Write("\nEnter Account Number : ");
                        string viewAccNum = Console.ReadLine() ?? string.Empty;
                        BankAccount? accountToView = controller.GetAccount(viewAccNum);
                        if (accountToView == null)
                        {
                            ConsoleHelper.Error("Account not found.");
                            Console.ReadKey();
                            break;
                        }

                        string accType = accountToView is SavingsAccount ? "Savings Account" : "Checking Account";
                        Console.WriteLine($"\n--- Account Details ---" +
                            $"\nAccount Number  : {accountToView.AccountNumber}" +
                            $"\nAccount Holder  : {accountToView.AccountHolder}" +
                            $"\nAccount Type    : {accType}" +
                            $"\nAccount Balance : ${accountToView.AccountBalance}");
                        Console.ReadKey();
                        break;

                    case BankMenu.DepositAmount:
                        Console.Write("\nEnter Account Number : ");
                        string depAccNum = Console.ReadLine() ?? string.Empty;
                        BankAccount? depAccount = controller.GetAccount(depAccNum);
                        if (depAccount == null)
                        {
                            ConsoleHelper.Error("Account not found.");
                            Console.ReadKey();
                            break;
                        }

                        decimal depAmount = ConsoleHelper.ReadDecimal("Enter amount to Deposit : ", "Amount", 1, 1000000000, 3, -99);
                        if (depAmount == -99)
                        {
                            Console.ReadKey();
                            break;
                        }

                        if (controller.Deposit(depAccount, depAmount))
                        {
                            Console.WriteLine($"\nAmount Deposited Successfully!\nCurrent Balance : ${depAccount.AccountBalance}");
                        }
                        else
                        {
                            ConsoleHelper.Error("Deposit failed. Please enter a valid positive amount.");
                        }

                        Console.ReadKey();
                        break;

                    case BankMenu.WithdrawAmount:
                        Console.Write("\nEnter Account Number : ");
                        string withAccNum = Console.ReadLine() ?? string.Empty;
                        BankAccount? withAccount = controller.GetAccount(withAccNum);
                        if (withAccount == null)
                        {
                            ConsoleHelper.Error("Account not found.");
                            Console.ReadKey();
                            break;
                        }

                        decimal withAmount = ConsoleHelper.ReadDecimal("Enter amount to Withdraw : ", "Amount", 1, 1000000000, 3, -99);
                        if (withAmount == -99)
                        {
                            Console.ReadKey();
                            break;
                        }

                        if (controller.Withdraw(withAccount, withAmount))
                        {
                            Console.WriteLine($"\nAmount Withdrawn Successfully!\nCurrent Balance : ${withAccount.AccountBalance}");
                        }
                        else
                        {
                            if (withAccount is SavingsAccount savings && (withAccount.AccountBalance - withAmount) < savings.MinimumBalance)
                            {
                                ConsoleHelper.Error($"Withdrawal failed! Savings account requires maintaining a minimum balance of ${savings.MinimumBalance}.");
                            }
                            else
                            {
                                ConsoleHelper.Error("Withdrawal failed! Insufficient balance.");
                            }
                        }

                        Console.ReadKey();
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