using Assignment2.BankAccountModels;
using Assignment2.BankAccountServices;
using Assignment2.EmployeeModels;
using Assignment2.Helpers;
using Assignment2.Models;
using Assignment2.Models.Menus;

namespace Assignment2.Views
{
    /// <summary>
    /// Console View class
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Displays shape Menu.
        /// </summary>
        public static void ShowShapeMenu()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();

                Console.WriteLine(@"----- Shape Menu -----
1. Rectangle
2. Circle
3. Back");

                ShapeMenu choice = (ShapeMenu)InputReader.ReadInt("Enter your choice : ", "Choice", 1, 4, 3, -1);
                if ((int)choice == -1)
                {
                    Console.ReadKey();
                    choice = ShapeMenu.Back;
                }

                switch (choice)
                {
                    case ShapeMenu.Rectangle:
                        ShapeModels.Rectangle rect = new ();
                        rect.Colour = InputReader.ReadString("Enter colour of the shape : ", "Colour", 10, 3, "@@@");
                        if (rect.Colour == "@@@")
                        {
                            Console.ReadKey();
                            break;
                        }

                        rect.Length = InputReader.ReadDouble("Enter the Length : ", "Length", 1, 1000000, 3, -1);
                        if (rect.Length == -1)
                        {
                            Console.ReadKey();
                            break;
                        }

                        rect.Width = InputReader.ReadDouble("Enter the Width : ", "Width", 1, 1000000, 3, -1);
                        if (rect.Width == -1)
                        {
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine($"\nArea of the rectangle : {rect.CalculateArea()}");
                        Console.ReadKey();
                        break;

                    case ShapeMenu.Circle:
                        ShapeModels.Circle circle = new ();
                        circle.Colour = InputReader.ReadString("Enter colour of the shape : ", "Colour", 10, 3, "@@@");
                        if (circle.Colour == "@@@")
                        {
                            Console.ReadKey();
                            break;
                        }

                        circle.Radius = InputReader.ReadDouble("Enter the Radius : ", "Radius", 1, 1000000, 3, -1);
                        if (circle.Radius == -1)
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
                        InputReader.Error("\nInvalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Displays Employee Menu.
        /// </summary>
        public static void ShowEmployeeMenu()
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();

                Console.WriteLine(@"----- Employee Menu -----
1.Manager
2.Developer
3.Back");
                EmployeeMenu choice = (EmployeeMenu)InputReader.ReadInt("\nEnter your choice : ", "Choice", 1, 4, 3, -1);
                if ((int)choice == -1)
                {
                    Console.ReadKey();
                    choice = EmployeeMenu.Back;
                }

                switch (choice)
                {
                    case EmployeeMenu.Manager:
                        Manager manager = new ();
                        manager.Salary = InputReader.ReadDecimal("\nEnter your Salary : ", "Salary", 0, 1000000000, 3, -1);
                        if (manager.Salary == -1)
                        {
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine($"\nYour Bonus amount is : {manager.CalculateBonus()}");
                        Console.ReadKey();
                        break;

                    case EmployeeMenu.Developer:
                        Developer developer = new ();
                        developer.Salary = InputReader.ReadDecimal("Enter your Salary : ", "Salary", 0, 1000000000, 3, -1);
                        if (developer.Salary == -1)
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
                        InputReader.Error("\nInvalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Displays Bank Menu.
        /// </summary>
        /// <param name="bankServices">Object of BankServices</param>
        public static void ShowBankMenu(BankServices bankServices)
        {
            bool back = false;

            while (!back)
            {
                Console.Clear();

                Console.WriteLine(@"----- Bank Menu -----
1.Create Account
2.View Account Details
3.Deposit Amount
4.Withdraw Amount
5.Back");

                BankMenu choice = (BankMenu)InputReader.ReadInt("\nEnter your choice : ", "Choice", 1, 6, 3, -1);
                if ((int)choice == -1)
                {
                    Console.ReadKey();
                    choice = BankMenu.Back;
                }

                switch (choice)
                {
                    case BankMenu.CreateAccount:
                        Console.WriteLine(@"--- Create Account ---
1. Savings Account
2. Checking Account");

                        BankAccountTypeMenu accountTypeChoice = (BankAccountTypeMenu)InputReader.ReadInt("Select Account Type : ", "Choice", 1, 3, 3, -1);
                        if ((int)accountTypeChoice == -1)
                        {
                            Console.ReadKey();
                            break;
                        }

                        string name = InputReader.ReadString("Enter Account Holder Name : ", "Account Holder Name", 30, 3, "@@@");
                        if (name == "@@@")
                        {
                            Console.ReadKey();
                            break;
                        }

                        if (accountTypeChoice == BankAccountTypeMenu.SavingsAccount)
                        {
                            decimal initialDeposit = InputReader.ReadDecimal($"Enter Initial Deposit : ", "Initial Deposit", 1, 1000000000, 3, -1);
                            if (initialDeposit == -1)
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
                                InputReader.Error($"Initial deposit must be at least ${savingsAccount.MinimumBalance} for a Savings Account.");
                                Console.ReadKey();
                                break;
                            }

                            bankServices.CreateAccount(savingsAccount);
                            InputReader.Success($"\nSavings Account Created Successfully!\nAccount Number : {savingsAccount.AccountNumber}\nAccount Balance : ${savingsAccount.AccountBalance}");
                            Console.ReadKey();
                        }
                        else if (accountTypeChoice == BankAccountTypeMenu.CheckingAccount)
                        {
                            decimal initialDeposit = InputReader.ReadDecimal("Enter Initial Deposit : ", "Initial Deposit", 0, 1000000000, 3, -1);
                            if (initialDeposit == -1)
                            {
                                Console.ReadKey();
                                break;
                            }

                            CheckingAccount checkingAccount = new CheckingAccount
                            {
                                AccountHolder = name,
                                AccountBalance = initialDeposit,
                            };

                            bankServices.CreateAccount(checkingAccount);
                            InputReader.Success($"\nChecking Account Created Successfully!\nAccount Number : {checkingAccount.AccountNumber}\nAccount Balance : ${checkingAccount.AccountBalance}");
                            Console.ReadKey();
                        }
                        else
                        {
                            InputReader.Error("\nInvalid Account Type.");
                            Console.ReadKey();
                        }

                        break;

                    case BankMenu.ViewAccountDetails:
                        Console.Write("\nEnter Account Number : ");
                        string viewAccNum = Console.ReadLine() ?? string.Empty;
                        BankAccount? accountToView = bankServices.GetAccount(viewAccNum);
                        if (accountToView == null)
                        {
                            InputReader.Error("Account not found.");
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
                        BankAccount? depAccount = bankServices.GetAccount(depAccNum);
                        if (depAccount == null)
                        {
                            InputReader.Error("Account not found.");
                            Console.ReadKey();
                            break;
                        }

                        decimal depAmount = InputReader.ReadDecimal("Enter amount to Deposit : ", "Amount", 1, 1000000000, 3, -1);
                        if (depAmount == -1)
                        {
                            Console.ReadKey();
                            break;
                        }

                        if (bankServices.Deposit(depAccount, depAmount))
                        {
                            InputReader.Success($"\nAmount Deposited Successfully!\nCurrent Balance : ${depAccount.AccountBalance}");
                        }
                        else
                        {
                            InputReader.Error("Deposit failed. Please enter a valid positive amount.");
                        }

                        Console.ReadKey();
                        break;

                    case BankMenu.WithdrawAmount:
                        Console.Write("\nEnter Account Number : ");
                        string withAccNum = Console.ReadLine() ?? string.Empty;
                        BankAccount? withAccount = bankServices.GetAccount(withAccNum);
                        if (withAccount == null)
                        {
                            InputReader.Error("Account not found.");
                            Console.ReadKey();
                            break;
                        }

                        decimal withAmount = InputReader.ReadDecimal("Enter amount to Withdraw : ", "Amount", 1, 1000000000, 3, -1);
                        if (withAmount == -1)
                        {
                            Console.ReadKey();
                            break;
                        }

                        if (bankServices.Withdraw(withAccount, withAmount))
                        {
                            InputReader.Success($"\nAmount Withdrawn Successfully!\nCurrent Balance : ${withAccount.AccountBalance}");
                        }
                        else
                        {
                            if (withAccount is SavingsAccount savings && (withAccount.AccountBalance - withAmount) < savings.MinimumBalance)
                            {
                                InputReader.Error($"Withdrawal failed! Savings account requires maintaining a minimum balance of ${savings.MinimumBalance}.");
                            }
                            else
                            {
                                InputReader.Error("Withdrawal failed! Insufficient balance.");
                            }
                        }

                        Console.ReadKey();
                        break;

                    case BankMenu.Back:
                        back = true;
                        break;

                    default:
                        InputReader.Error("\nInvalid Choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
