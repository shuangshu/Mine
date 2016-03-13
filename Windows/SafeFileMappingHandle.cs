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
    public sealed class SafeFileMappingHandle : SafeHandleZeroOrMinusOneIsInvalid 
    { 
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        public SafeFileMappingHandle() : base(true) {} 

        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
        public SafeFileMappingHandle(IntPtr handle, bool ownsHandle) : base (ownsHandle) 
        {
            SetHandle(handle); 
        } 

        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)]
        override protected bool ReleaseHandle()
        {
            return Win32Native.CloseHandle(handle); 
        }
    } 
} 

