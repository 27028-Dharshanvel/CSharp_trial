namespace Assignment8
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
            int number1;
            if (int.TryParse(Console.ReadLine(), out number1))
            {
                Console.WriteLine($"Index: {number1}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            Console.Write("Enter second number for Task 1: ");
            int number2;
            if (int.TryParse(Console.ReadLine(), out number2))
            {
                Console.WriteLine($"Index: {number2}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            Tasks.TaskOne(number1, number2);

            Console.Write("\nEnter the number of elements for the array in Task 2: ");
            int size;
            if (int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine($"Index: {size}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            int[] numbers = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter element " + i + ": ");
                if (int.TryParse(Console.ReadLine(), out numbers[i]))
                {
                    Console.WriteLine(numbers[i]);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }

            Console.Write("Enter an index to access: ");

            int index;
            if (int.TryParse(Console.ReadLine(), out index))
            {
                Console.WriteLine($"Index: {index}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            Tasks.TaskTwo(numbers, index);

            Tasks.TaskThree();

            Tasks.TaskFour();

            Tasks.TaskFive();
        }
    }
}