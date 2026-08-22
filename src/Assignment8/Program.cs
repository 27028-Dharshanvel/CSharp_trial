namespace Assignments
{
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Command line arguments.</param>
            public static void Main(string[] args)
            {
                    TaskOne();
                    TaskTwo();
                    TaskThree();
                    TaskFour();
                    TaskFive();
            }

            /// <summary>
            /// Task one
            /// </summary>
            public static void TaskOne()
            {
                Console.WriteLine("\n--- Task 1 ---");

                try
                {
                    int number1 = 10;
                    int number2 = 0;

                    int result = number1 / number2;

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
            /// Tasktwo
            /// </summary>
            public static void TaskTwo()
            {
                Console.WriteLine("\n--- Task 2 ---");

                int[] numbers = { 10, 20, 30 };

                try
                {
                    Console.WriteLine("Array value: " + numbers[5]);
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
            /// Task three
            /// </summary>
            public static void TaskThree()
            {
                Console.WriteLine("\n--- Task 3 ---");

                try
                {
                    Console.Write("Enter a number: ");
                    string input = Console.ReadLine();

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
            /// Task Four.
            /// </summary>
            public static void TaskFour()
            {
                Console.WriteLine("\n--- Task 4 ---");

                AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;

                Console.WriteLine("Global unhandled exception handler has been registered.");
                Console.WriteLine("UnhandledExceptionMethod() is available to demonstrate it.");
            }

            /// <summary>
            /// Exception method
            /// </summary>
            /// <exception cref="Exception">exception</exception>
            public static void UnhandledExceptionMethod()
            {
                throw new Exception("This is an unhandled exception.");
            }

            /// <summary>
            /// Exception
            /// </summary>
            /// <param name="sender">sender</param>
            /// <param name="e">e</param>
            public static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
            {
                Console.WriteLine("Global handler caught an unhandled exception.");
                Console.WriteLine("Message: " + ((Exception)e.ExceptionObject).Message);
            }

            /// <summary>
            /// TaskFive
            /// </summary>
            public static void TaskFive()
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
