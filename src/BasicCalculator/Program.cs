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
                    continue;
                }

                if (!InputValidator.IsIntWithinRange(choice, 1, 5))
                {
                    Console.WriteLine("Select a valid choice between 1 - 5 : ");
                    continue;
                }

                ArithmeticOperationChoices userChoice = (ArithmeticOperationChoices)choice;

                switch (userChoice)
                {
                    case ArithmeticOperationChoices.Add:
                        Console.Write("Enter the first addend : ");
                        if (!InputValidator.IsValidInt(Console.ReadLine(), out int firstOperand))
                        {
                            Console.WriteLine("Enter a valid integer : ");
                            break;
                        }

                        Console.Write("Enter the second addend : ");
                        if (!InputValidator.IsValidInt(Console.ReadLine(), out int secondOperand))
                        {
                            Console.WriteLine("Enter a valid integer : ");
                            break;
                        }

                        try
                        {
                        Console.WriteLine("Sum : " + MathUtils.Add(firstOperand, secondOperand));
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine($"The result falls out of range for a 32 bit integer : Range({int.MinValue}, {int.MaxValue})");
                        }

                        break;

                    case ArithmeticOperationChoices.Subtract:
                        Console.Write("Enter the Minuend : ");
                        if (!InputValidator.IsValidInt(Console.ReadLine(), out int minuend))
                        {
                            Console.WriteLine("Enter a valid integer : ");
                            break;
                        }

                        Console.Write("Enter the Subtrahend : ");
                        if (!InputValidator.IsValidInt(Console.ReadLine(), out int subtrahend))
                        {
                            Console.WriteLine("Enter a valid integer : ");
                            break;
                        }

                        try
                        {
                            Console.WriteLine("Difference : " + MathUtils.Subtract(minuend, subtrahend));
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine($"The result falls out of range for a 32 bit integer : Range({int.MinValue}, {int.MaxValue})");
                        }

                        break;

                    case ArithmeticOperationChoices.Multiply:
                        Console.Write("Enter the Multiplicand : ");
                        if (!InputValidator.IsValidInt(Console.ReadLine(), out int multiplicand))
                        {
                            Console.WriteLine("Enter a valid integer : ");
                            break;
                        }

                        Console.Write("Enter the Multiplier : ");
                        if (!InputValidator.IsValidInt(Console.ReadLine(), out int multiplier))
                        {
                            Console.WriteLine("Enter a valid integer : ");
                            break;
                        }

                        try
                        {
                            Console.WriteLine("Product : " + MathUtils.Multiply(multiplicand, multiplier));
                        }
                        catch
                        {
                            Console.WriteLine($"The result falls out of range for a 32 bit integer : Range({int.MinValue}, {int.MaxValue})");
                        }

                        break;

                    case ArithmeticOperationChoices.Divide:
                        try
                        {
                            Console.Write("Enter the Dividend : ");
                            if (!InputValidator.IsValidInt(Console.ReadLine(), out int dividend))
                            {
                                Console.WriteLine("Enter a valid integer : ");
                                break;
                            }

                            Console.Write("Enter the Divisor : ");
                            if (!InputValidator.IsValidInt(Console.ReadLine(), out int divisor))
                            {
                                Console.WriteLine("Enter a valid integer : ");
                                break;
                            }

                            Console.WriteLine("Quotient : " + MathUtils.Divide(dividend, divisor));
                        }
                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Cannot divide a number by 0");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine($"The result falls out of range for a 32 bit integer : Range({int.MinValue}, {int.MaxValue})");
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