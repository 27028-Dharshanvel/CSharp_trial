namespace GarbageCollection;

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
        int sampleInteger = 10;
        Student student = new Student("Dharshan");
        ModifyInputs(sampleInteger, student);
        Console.WriteLine(@$"Integer is not modified : {sampleInteger}
String is Modified : {student.Name}");
    }

    /// <summary>
    /// Modifies inputs
    /// </summary>
    /// <param name="sampleInteger">sample Integer</param>
    /// <param name="student">sample string</param>
    public static void ModifyInputs(int sampleInteger, Student student)
    {
        sampleInteger = 20;
        student.Name = "vel";
    }

    /// <summary>
    /// Creates a large array
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
    /// Calculates many local variables
    /// </summary>
    /// <returns>int</returns>
    public static int CalculateWithManyLocals()
    {
        int v1 = 10, v2 = 20, v3 = 30, v4 = 40, v5 = 50;
        int v6 = 60, v7 = 70, v8 = 80, v9 = 90, v10 = 100;

        int result = (v1 + v2 + v3 + v4 + v5) * (v6 - v7 + v8 - v9 + v10);

        return result;
    }
}