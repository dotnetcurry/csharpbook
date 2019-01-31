using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Finalizers
{
    public class ClassWithSafeHandle : IDisposable
    {
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr CreateFile(
            string fileName,
            [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
            [MarshalAs(UnmanagedType.U4)] FileShare fileShare,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
            IntPtr template);

        bool disposed = false;
        SafeFileHandle safeHandle;

        public ClassWithSafeHandle(string filename)
        {
            var unsafeHandle = CreateFile(filename, FileAccess.Read, FileShare.Read, IntPtr.Zero, FileMode.Open, FileAttributes.Normal, IntPtr.Zero);
            safeHandle = new SafeFileHandle(unsafeHandle, true);
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
                if (safeHandle != null && !safeHandle.IsInvalid)
                {
                    safeHandle.Dispose();
                    safeHandle = null;
                }
            }
            disposed = true;
        }
    }

}
