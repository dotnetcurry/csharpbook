using System;
using System.IO;

namespace IDisposableInterface
{
    public class DisposableClass : IDisposable
    {
        bool disposed = false;
        private StreamReader reader;

        public DisposableClass(string filename)
        {
            reader = new StreamReader(filename);
        }

        public string Read()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(nameof(DisposableClass));
            }
            return reader.ReadToEnd();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (reader != null)
                {
                    reader.Dispose();
                    reader = null;
                }
            }
            disposed = true;
        }
    }

}
