using System.Reflection.Metadata.Ecma335;
using System.Transactions;
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
            bool isAppRunning = true;
            while (isAppRunning)
            {
                Console.WriteLine(@$"Hello user....
Select the Arithmetic operation to perform 

1.Add
2.Subtract
3.Multiply
4.Divide
5.Exit");

                if (!InputValidator.IsValidInt(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Enter a valid choice : ");
                    return;
                }

                if (!InputValidator.IsIntWithinRange(choice, 1, 5))
                {
                    Console.WriteLine("Select a valid choice between 1 - 5 : ");
                    return;
                }

                ArithmeticOperationChoices userChoice = (ArithmeticOperationChoices)choice;
                Console.Write("Enter the first operand : ");
                if (!InputValidator.IsValidInt(Console.ReadLine(), out int firstOperand))
                {
                    Console.WriteLine("Enter a valid choice : ");
                    return;
                }

                Console.Write("Enter the second operand : ");
                if (!InputValidator.IsValidInt(Console.ReadLine(), out int secondOperand))
                {
                    Console.WriteLine("Enter a valid choice : ");
                    return;
                }

                switch (userChoice)
                {
                    case ArithmeticOperationChoices.Add:
                        Console.WriteLine("Sum : " + MathUtils.Add(firstOperand, secondOperand));
                        break;
                    case ArithmeticOperationChoices.Subtract:
                        Console.WriteLine("Difference : " + MathUtils.Subtract(firstOperand, secondOperand));
                        break;
                    case ArithmeticOperationChoices.Multiply:
                        Console.WriteLine("Product : " + MathUtils.Multiply(firstOperand, secondOperand));
                        break;
                    case ArithmeticOperationChoices.Divide:
                        try
                        {
                            Console.WriteLine("Quotient : " + MathUtils.Divide(firstOperand, secondOperand));
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Cannot divide a number by 0");
                        }

                        break;
                    case ArithmeticOperationChoices.Exit:
                        isAppRunning = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}