using System;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Versioning;
using Microsoft.Win32;

namespace Windows
{

    public sealed class SafeRegistryHandle : SafeHandleZeroOrMinusOneIsInvalid
    {

        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        public SafeRegistryHandle() : base(true) { }

        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        public SafeRegistryHandle(IntPtr preexistingHandle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(preexistingHandle);
        }

        [DllImport(Win32Native.ADVAPI32),
         SuppressUnmanagedCodeSecurity,
         ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        private static extern int RegCloseKey(IntPtr hKey);

        override protected bool ReleaseHandle()
        {
            int r = RegCloseKey(handle);
            return r == 0;
        }
    }
}
