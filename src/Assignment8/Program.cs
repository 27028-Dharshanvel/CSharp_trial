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
            Console.Write("Enter first number for Task 1: ");
            int number1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number for Task 1: ");
            int number2 = int.Parse(Console.ReadLine());

            TaskOne(number1, number2);

            Console.Write("\nEnter the number of elements for the array in Task 2: ");
            int size = int.Parse(Console.ReadLine());

            int[] numbers = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter element " + i + ": ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter an index to access: ");
            int index = int.Parse(Console.ReadLine());

            TaskTwo(numbers, index);

            TaskThree();

            TaskFour();

            TaskFive();
        }

        /// <summary>
        /// Task one
        /// </summary>
        /// <param name="number1">first input number</param>
        /// <param name="number2">second input number</param>
        public static void TaskOne(int number1, int number2)
        {
            Console.WriteLine("\n--- Task 1 ---");

            try
            {
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
        /// /// <param name="numbers">Input number</param>
        /// <param name="index">index of the array</param>
        public static void TaskTwo(int[] numbers, int index)
        {
            Console.WriteLine("\n--- Task 2 ---");

            try
            {
                Console.WriteLine("Array value: " + numbers[index]);
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