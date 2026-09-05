using System.Diagnostics;

namespace GarbageCollection
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of program
        /// </summary>
        /// <param name="args">Cmd Line args</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        /// <summary>
        /// SimulateObjects count 
        /// </summary>
        /// <param name="iterationCount">count</param>
        public static void SimulateObjectChurn(int iterationCount)
        {
            Console.WriteLine($"Starting allocation of {iterationCount:N0} objects...\n");

            Stopwatch sw = Stopwatch.StartNew();
            int gc0Before = GC.CollectionCount(0);
            int gc1Before = GC.CollectionCount(1);
            int gc2Before = GC.CollectionCount(2);

            for (int i = 0; i < iterationCount; i++)
            {
                Student student = new Student(i);

                if (student.Id == -1)
                {
                    Console.WriteLine("This will never hit, but keeps the object alive for the scope.");
                }
            }

            sw.Stop();

            int gc0After = GC.CollectionCount(0);
            int gc1After = GC.CollectionCount(1);
            int gc2After = GC.CollectionCount(2);

            Console.WriteLine($"Allocation completed in: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"Gen 0 Collections: {gc0After - gc0Before}");
            Console.WriteLine($"Gen 1 Collections: {gc1After - gc1Before}");
            Console.WriteLine($"Gen 2 Collections: {gc2After - gc2Before}");
        }
    }
}