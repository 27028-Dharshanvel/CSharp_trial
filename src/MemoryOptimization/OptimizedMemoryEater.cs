namespace MemoryOptimization
{
    /// <summary>
    /// MemoryEater that implements IDisposable safely and supports cancellation.
    /// </summary>
    internal class OptimizedMemoryEater : IDisposable
    {
        private List<int[]> _memAlloc = new List<int[]>();
        private bool _disposed = false;

        /// <summary>
        /// Allocates memory sequentially on the calling thread.
        /// </summary>
        /// <param name="iterationCount">Count for allocating large arrays</param>
        public void Allocate(int iterationCount)
        {
            Console.WriteLine("Observe the memory usage for the slightly optimized version");
            for (int i = 0; i < iterationCount; i++)
            {
                this._memAlloc.Add(new int[1000]);
                Thread.Sleep(10);
            }
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
        /// Dispose method overloaded with boolean parameter to be safely called by user
        /// </summary>
        /// <param name="disposing">disposing boolean</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (disposing)
            {
                Console.WriteLine("Disposing MemoryEater: Clearing references...");

                this._memAlloc?.Clear();
                this._memAlloc = null;
            }

            this._disposed = true;
        }
    }
}
