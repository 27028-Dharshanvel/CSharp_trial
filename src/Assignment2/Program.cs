using Assignment2.BankAccountServices;
using Assignment2.Controllers;

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
                        Console.WriteLine("Enter the Length :");
                        
                        break;

                    case ShapeMenu.Circle:
                        // TODO : Circle operations
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
                        // TODO : Manager operations
                        break;

                    case EmployeeMenu.Developer:
                        // TODO : Developer operations
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
                        // TODO : Savings Account operations
                        break;

                    case BankMenu.CheckingAccount:
                        // TODO : Checking Account operations
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