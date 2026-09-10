namespace MemoryOptimization
{
    /// <summary>
    /// MemoryEater that implements IDisposable
    /// </summary>
    internal class OptimizedMemoryEater : IDisposable
    {
        private List<int[]> _memAlloc = new List<int[]>();
        private bool _disposed = false;

        /// <summary>
        /// Allocates memory with a limit.
        /// </summary>
        /// <param name="iterations">iterations of allocation</param>
        public void Allocate(int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                this._memAlloc.Add(new int[1000]);
                Thread.Sleep(10);
            }

            Console.WriteLine($"Allocated {this._memAlloc.Count} arrays.");
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing">disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    // 2. Clear the managed list to release references to the large int arrays
                    Console.WriteLine("Disposing MemoryEater: Clearing references...");
                    this._memAlloc.Clear();
                    this._memAlloc = null;
                }

                this._disposed = true;
            }
        }
    }
}
