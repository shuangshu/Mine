using System; 
using System.Security; 
using System.Security.Permissions;
using System.Runtime.InteropServices; 
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32;

namespace Windows
{
    public sealed class SafeFindHandle : SafeHandleZeroOrMinusOneIsInvalid 
    { 
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        public SafeFindHandle() : base(true) {} 

        override protected bool ReleaseHandle()
        {
            return Win32Native.FindClose(handle); 
        }
    } 
} 
