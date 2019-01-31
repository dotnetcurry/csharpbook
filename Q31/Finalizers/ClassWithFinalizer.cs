using System;
using System.Runtime.InteropServices;

namespace Finalizers
{
    public class ClassWithFinalizer : IDisposable
    {
        bool disposed = false;
        IntPtr unsafeHandle;

        public ClassWithFinalizer(int size)
        {
            unsafeHandle = Marshal.AllocHGlobal(size);
        }

        ~ClassWithFinalizer()
        {
            Dispose(false);
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
                // dispose nested disposable instances
            }
            if (unsafeHandle != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(unsafeHandle);
                unsafeHandle = IntPtr.Zero;
            }
            disposed = true;
        }
    }
}
