using System.Reflection.Metadata.Ecma335;
using MathUtility;

namespace BasicCalculator
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the program.
        /// </summary>
        /// <param name="args">CMD line args</param>
        public static void Main(string[] args)
        {
            Console.WriteLine(@$"Hello user....
Select the Arithmetic operation to perform 

1.Add
2.Subtract
3.Multiply
4.Divide");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            Console.Write("Enter the first operand : ");
            int operand1;
            if (int.TryParse(Console.ReadLine(), out operand1))
            {
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            Console.Write("Enter the second operand : ");
            int operand2;
            if (int.TryParse(Console.ReadLine(), out operand2))
            {
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Sum : " + MathUtils.Add(operand1, operand2));
                    break;
                case 2:
                    Console.WriteLine("Difference : " + MathUtils.Subtract(operand1, operand2));
                    break;
                case 3:
                    Console.WriteLine("Product : " + MathUtils.Multiply(operand1, operand2));
                    break;
                case 4:
                    Console.WriteLine("Quotient : " + MathUtils.Divide(operand1, operand2));
                    break;
            }
        }
    }
}