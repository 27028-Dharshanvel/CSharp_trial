namespace MemoryOptimization
{
    /// <summary>
    /// MemoryEater that implements IDisposable safely and supports cancellation.
    /// </summary>
    internal class OptimizedMemoryEater : IDisposable
    {
        private List<int[]> _memAlloc = new List<int[]>();
        private bool _disposed = false;
        private readonly object _lock = new object();

        /// <summary>
        /// Allocates memory safely until disposed or memory runs out.
        /// </summary>
        /// <param name="iterationCount">iterationCount</param>
        public void Allocate(int iterationCount)
        {
            for(int i = 0; i < iterationCount; i++)
            {
                lock (_lock)
                {
                    if (_disposed || _memAlloc == null)
                    {
                        break;
                    }

                    this._memAlloc.Add(new int[1000]);
                }

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
        /// Dispose method
        /// </summary>
        /// <param name="disposing">disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (disposing)
            {
                lock (_lock)
                {
                    Console.WriteLine("Disposing MemoryEater: Clearing references...");

                    this._memAlloc?.Clear();
                    this._memAlloc = null;
                }
            }

            this._disposed = true;
        }
    }
}
