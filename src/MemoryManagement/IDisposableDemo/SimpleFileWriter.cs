namespace IDisposableDemo
{
    /// <summary>
    /// Simple file writer class which implements IDisposable interface.
    /// </summary>
    internal class SimpleFileWriter : IDisposable
    {
        private StreamWriter? _writer;
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleFileWriter"/> class.
        /// </summary>
        /// <param name="filePath">filepath</param>
        public SimpleFileWriter(string filePath)
        {
            this._writer = new StreamWriter(filePath, append: false);
        }

        /// <summary>
        /// Writes a line on the file.
        /// </summary>
        /// <param name="text">text</param>
        /// <exception cref="ObjectDisposedException">Exception, that might be thrown if object was disposed.</exception>
        public void WriteLine(string text)
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException(nameof(SimpleFileWriter), "Cannot write to a closed file.");
            }

            this._writer.WriteLine(text);
        }

        /// <summary>
        /// Dispose method to clean up the resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose method to called by user.
        /// </summary>
        /// <param name="disposing">True when called user , False otherwise.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing && this._writer != null)
            {
                this._writer.Dispose();
                this._writer = null;
            }

            this._disposed = true;
        }
    }
}
