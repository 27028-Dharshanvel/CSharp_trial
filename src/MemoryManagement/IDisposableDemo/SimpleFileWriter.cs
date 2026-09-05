using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableDemo
{
    /// <summary>
    /// Simple file writer
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
        /// Writes a line
        /// </summary>
        /// <param name="text">text</param>
        /// <exception cref="ObjectDisposedException">exception</exception>
        public void WriteLine(string text)
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException(nameof(SimpleFileWriter), "Cannot write to a closed file.");
            }

            this._writer.WriteLine(text);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">boolean</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (this._writer != null)
                    {
                        this._writer.Dispose();
                        this._writer = null;
                    }
                }

                this._disposed = true;
            }
        }
    }
}
