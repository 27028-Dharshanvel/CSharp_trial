using MemoryOptimization;

namespace Assignments
{
    /// <summary>
    /// Memory eater class
    /// </summary>
    internal class MemoryEater
    {
        private List<int[]> _memAlloc = new List<int[]>();

        /// <summary>
        /// Allocate method
        /// </summary>
        public void Allocate()
        {
            Console.WriteLine(@"Memory allocation starts....Observe the memory usage with performance profiler

Restart the application to implement other cases.
(Memory allocation runs on infinte loop , might throw OutOfMemoryException)");
            while (true)
            {
                this._memAlloc.Add(new int[10000]);
                Thread.Sleep(10);
            }
        }
    }
}