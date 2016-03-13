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
    public sealed class SafePEFileHandle: SafeHandleZeroOrMinusOneIsInvalid 
    {
        private SafePEFileHandle(IntPtr handle) : base (true)
        {
            SetHandle(handle);
        } 

        public static SafePEFileHandle InvalidHandle 
        { 
            get { return new SafePEFileHandle(IntPtr.Zero); }
        } 

        override protected bool ReleaseHandle()
        {
            return true; 
        }
    } 
}

