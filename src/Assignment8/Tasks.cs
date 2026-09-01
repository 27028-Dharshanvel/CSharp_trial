using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignments;

namespace Assignment8
{
    /// <summary>
    /// Tasks class.
    /// </summary>
    internal static class Tasks
    {
        /// <summary>
        /// Task to perform divide operation and catch DivideByZeroException.
        /// </summary>
        /// <param name="dividend">Dividend input number</param>
        /// <param name="divisor">Divisor input number</param>
        public static void DemonstrateDivideByZeroException(int dividend, int divisor)
        {
            Console.WriteLine("\n--- Task 1 ---");

            try
            {
                Console.WriteLine(@$"Demonstration of dividing a number by zero : 
Dividend : {dividend}
Divisor : {divisor}");

                int result = dividend / divisor;

                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide a number by zero.");
            }
            finally
            {
                Console.WriteLine("Finally block has been executed.");
            }
        }

        /// <summary>
        /// Task to access an element from array and catch IndexOutOfRangeException.
        /// </summary>
        /// /// <param name="numbers">Input number</param>
        public static void DemonstrateIndexOutOfRangeException(int[] numbers)
        {
            Console.WriteLine("\n--- Demonstration of IndexOutofBoundException---");

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(numbers[i] + " ");
                }

                Console.WriteLine("Accesing value from array within its range (Sample Index - 9) : ");
                Console.WriteLine(numbers[9]);
                Console.WriteLine("Accesing value from array out of its range (Sample Index - 11) : ");
                Console.WriteLine(numbers[11]);
            }
            catch (IndexOutOfRangeException)
            {
                try
                {
                    throw new Exception("Custom message: The requested array index is out of range.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Task to prompt user to enter an integer and catch InvalidUserInputException.
        /// </summary>
        public static void DemonstrateInvalidUserInputException()
        {
            Console.WriteLine("\n--- Task 3 ---");

            try
            {
                Console.Write("Enter a number: ");
                string? input = Console.ReadLine();

                int number;

                if (int.TryParse(input, out number) == false)
                {
                    throw new InvalidUserInputException(
                        "Invalid user input. Please enter a valid integer.");
                }

                Console.WriteLine("You entered: " + number);
            }
            catch (InvalidUserInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Task to implement UnhandledException.
        /// </summary>
        public static void DemonstrateUnhandledException()
        {
            Console.WriteLine("\n--- Task 4 ---");

            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;

            Console.WriteLine("Global unhandled exception handler has been registered.");
            Console.WriteLine("UnhandledExceptionMethod() is available to demonstrate it.");
        }

        /// <summary>
        /// Exception method for unhandled exception.
        /// </summary>
        /// <exception cref="Exception">exception</exception>
        public static void UnhandledExceptionMethod()
        {
            throw new Exception("This is an unhandled exception.");
        }

        /// <summary>
        /// Exception method to handle unhandled exception.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Global handler caught an unhandled exception.");
            Console.WriteLine("Message: " + ((Exception)e.ExceptionObject).Message);
        }

        /// <summary>
        /// Task to demonstrate stack trace.
        /// </summary>
        public static void DemonstrateStackTrace()
        {
            Console.WriteLine("\n--- Task 5 ---");

            try
            {
                throw new Exception("This exception is created for stack trace demonstration.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught.");
                Console.WriteLine("\nStack Trace:");
                Console.WriteLine(ex.StackTrace);

                Console.WriteLine("\nStack Trace Interpretation:");
            }
        }
    }
}
