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
            while (true)
            {
                this._memAlloc.Add(new int[10000]);
                Thread.Sleep(10);
            }
        }
    }
}