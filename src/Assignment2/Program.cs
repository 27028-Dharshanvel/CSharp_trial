using System.Drawing;
using System.Runtime.CompilerServices;
using Assignment2.BankAccountModels;
using Assignment2.BankAccountServices;
using Assignment2.Controllers;
using Assignment2.EmployeeModels;
using Assignment2.Helpers;
using Assignment2.ShapeModels;

namespace Assignment2
{
    /// <summary>
    /// Represents program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Enum for Mainmenu
        /// </summary>
        public enum MainMenu
        {
            /// <summary>
            /// shape
            /// </summary>
            Shape = 1,

            /// <summary>
            /// Employee
            /// </summary>
            Employee,

            /// <summary>
            /// BankAccount
            /// </summary>
            BankAccount,

            /// <summary>
            /// exit
            /// </summary>
            Exit,
        }

        /// <summary>
        /// ShapeMenu
        /// </summary>
        public enum ShapeMenu
        {
            /// <summary>
            /// Rectangle
            /// </summary>
            Rectangle = 1,

            /// <summary>
            /// Circle
            /// </summary>
            Circle,

            /// <summary>
            /// Back
            /// </summary>
            Back,
        }

        /// <summary>
        /// EmployeeMenu
        /// </summary>
        public enum EmployeeMenu
        {
            /// <summary>
            /// Manager
            /// </summary>
            Manager = 1,

            /// <summary>
            /// Developer
            /// </summary>
            Developer,

            /// <summary>
            /// Back
            /// </summary>
            Back,
        }

        /// <summary>
        /// BankMenu
        /// </summary>
        public enum BankMenu
        {
            /// <summary>
            /// SavingsAccount
            /// </summary>
            SavingsAccount = 1,

            /// <summary>
            /// CheckingAccount
            /// </summary>
            CheckingAccount,

            /// <summary>
            /// Back
            /// </summary>
            Back,
        }

        /// <summary>
        /// BankingOperations Enumerator
        /// </summary>
        public enum BankingOperations
        {
            /// <summary>
            /// Deposit
            /// </summary>
            Deposit = 1,

            /// <summary>
            /// Withdraw
            /// </summary>
            Withdraw,
        }

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

                Console.Write("\nEnter your choice : ");

                MainMenu choice = (MainMenu)Convert.ToInt32(Console.ReadLine());

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

                Console.WriteLine("----- Shape Menu -----");
                Console.WriteLine("1. Rectangle");
                Console.WriteLine("2. Circle");
                Console.WriteLine("3. Back");

                Console.Write("\nEnter your choice : ");

                ShapeMenu choice = (ShapeMenu)Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case ShapeMenu.Rectangle:
                        ShapeModels.Rectangle rect = new ();
                        rect.Length = Helper.ReadDouble("Enter the Length :");
                        rect.Width = Helper.ReadDouble("Enter the Width :");
                        Console.WriteLine($"\nArea of the circle :{rect.CalculateArea()}");
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

                Console.WriteLine("----- Employee Menu -----");
                Console.WriteLine("1. Manager");
                Console.WriteLine("2. Developer");
                Console.WriteLine("3. Back");

                Console.Write("\nEnter your choice : ");

                EmployeeMenu choice = (EmployeeMenu)Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case EmployeeMenu.Manager:
                        Manager manager = new ();
                        manager.Salary = Helper.ReadInt("Enter your Salary");
                        Console.WriteLine($"Your Bonus amount is : {manager.CalculateBonus()}");
                        Console.ReadKey();
                        break;

                    case EmployeeMenu.Developer:
                        Developer developer = new();
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

            while (!back)
            {
                Console.Clear();

                Console.WriteLine("----- Bank Menu -----");
                Console.WriteLine("1. Savings Account");
                Console.WriteLine("2. Checking Account");
                Console.WriteLine("3. Back");

                Console.Write("\nEnter your choice : ");

                BankMenu choice = (BankMenu)Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case BankMenu.SavingsAccount:
                        SavingsAccount savingsAccount1 = new ();
                        Helper.DisplayBankingOperations();
                        BankingOperations userChoice = (BankingOperations)Helper.ReadInt("Enter the operation to perform :");
                        switch (userChoice)
                        {
                            case BankingOperations.Deposit:

                                savingsAccount1.Deposit(Helper.ReadInt("Enter amount to Deposit :"));
                                Console.WriteLine("Amount Deposited");
                                Console.ReadKey();
                                break;

                            case BankingOperations.Withdraw:

                                savingsAccount1.Withdraw(Helper.ReadInt("Enter amount to Withdraw :"));
                                Console.WriteLine("Amount Withdrawn");
                                Console.ReadKey();
                                break;
                        }

                        break;

                    case BankMenu.CheckingAccount:
                        Helper.DisplayBankingOperations();
                        CheckingAccount checkingAccount1 = new ();
                        BankingOperations userChoice2 = (BankingOperations)Helper.ReadInt("Enter the operation to perform :");
                        switch (userChoice2)
                        {
                            case BankingOperations.Deposit:

                                checkingAccount1.Deposit(Helper.ReadInt("Enter amount to Deposit :"));
                                Console.WriteLine("Amount Deposited");
                                Console.ReadKey();
                                break;

                            case BankingOperations.Withdraw:

                                checkingAccount1.Withdraw(Helper.ReadInt("Enter amount to Withdraw :"));
                                Console.WriteLine("Amount Withdrawn");
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