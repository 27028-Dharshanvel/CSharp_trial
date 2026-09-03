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
                Console.WriteLine($"Index: {choice}");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            switch (choice)
            {
                case 1:
                    MathUtils.Add();
                    break;
                case 2:
                    MathUtils.Subtract();
                    break;
                case 3:
                    MathUtils.Divide();
                    break;
                case 4:
                    MathUtils.Multiply();
                    break;
                case 5:
                    MathUtils.Divide();
                    break;
            }
        }
    }
}