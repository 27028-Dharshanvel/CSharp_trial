using Assignment2.EmployeeModels;
using Assignment2.Helpers;
using Assignment2.Models;

namespace Assignment2.Views
{
    /// <summary>
    /// Console view for Employee Menu.
    /// </summary>
    internal class ConsoleEmployeeMenu
    {
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
    }
}
