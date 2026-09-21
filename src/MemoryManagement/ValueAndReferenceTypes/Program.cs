namespace ValueAndReferenceTypes;

/// <summary>
/// Program class
/// </summary>
internal class Program
{
    /// <summary>
    /// Entry point of the program
    /// </summary>
    /// <param name="args">CMD line args</param>
    public static void Main(string[] args)
    {
        bool isAppRunning = true;
        while (isAppRunning)
        {
            Console.Clear();
            Console.Write(@"------------Value and Reference types-----------

1.Demonstrate modification of a value and reference type.
2.Perform allocation of a large array of integers.
3.Perform calculation with a large number of local variables.
4.Exit application.

Enter your choice : ");

            if (!InputValidator.IsValidInt(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Please enter a valid choice");
                Console.ReadKey();
                continue;
            }

            if (!InputValidator.IsIntWithinRange(choice, 1, 4))
            {
                Console.WriteLine("Select a choice btween 1-4");
                Console.ReadKey();
                continue;
            }

            switch (choice)
            {
                case 1:
                    int sampleInteger = 10;
                    Student student = new Student("Dharshan");
                    Console.WriteLine(@$"Before Modification : 
Integer (Value type) = {sampleInteger}
student.Name (Reference type) = {student.Name}");

                    ModifyInputs(sampleInteger, student);

                    Console.WriteLine($@"
After Modification : 
Value type is not modified is not modified : {sampleInteger}
Refernce type is Modified : {student.Name}");
                    break;

                case 2:
                    Console.WriteLine(@"Performs allocation of a large array of inetegers.
View diagnostic tools to analyze memory usage");
                    Console.WriteLine(AllocateLargeArray(100000));
                    Console.ReadKey();
                    break;

                case 3:
                    Console.WriteLine(@"Performs calculation of many local variables.
View diagnostic tools to analyze memory usage");
                    Console.WriteLine(CalculateWithManyLocals());
                    Console.ReadKey();
                    break;

                case 4:
                    Console.WriteLine("Application Exiting");
                    isAppRunning = false;
                    break;
            }

            Console.ReadKey();
        }
    }

    /// <summary>
    /// Modifies a sample value type and reference type.
    /// </summary>
    /// <param name="sampleInteger">Value type to be modified.</param>
    /// <param name="student">Reference type to be modified.</param>
    public static void ModifyInputs(int sampleInteger, Student student)
    {
        sampleInteger = 20;
        student.Name = "D vel";
    }

    /// <summary>
    /// Creates a large array of integer
    /// </summary>
    /// <param name="size">size of array</param>
    /// <returns>long value</returns>
    public static long AllocateLargeArray(int size)
    {
        int[] largeArray = new int[size];

        for (int i = 0; i < largeArray.Length; i++)
        {
            largeArray[i] = i * 2;
        }

        long sum = 0;
        foreach (int value in largeArray)
        {
            sum += value;
        }

        return sum;
    }

    /// <summary>
    /// Calculates many local variables.
    /// </summary>
    /// <returns>Result integer</returns>
    public static int CalculateWithManyLocals()
    {
        int v1 = 10, v2 = 20, v3 = 30, v4 = 40, v5 = 50;
        int v6 = 60, v7 = 70, v8 = 80, v9 = 90, v10 = 100;

        int result = (v1 + v2 + v3 + v4 + v5) * (v6 - v7 + v8 - v9 + v10);

        return result;
    }
}