using System;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Versioning;
using Microsoft.Win32;
using System.Threading;

namespace Windows
{
 
    [SecurityPermission(SecurityAction.LinkDemand,UnmanagedCode=true)]
    public sealed class SafeWaitHandle : SafeHandleZeroOrMinusOneIsInvalid
    {

        private SafeWaitHandle() : base(true)
        { 
        } 

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        public SafeWaitHandle(IntPtr existingHandle, bool ownsHandle) : base(ownsHandle)
        {
            SetHandle(existingHandle);
        } 

        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)] 
        override protected bool ReleaseHandle()
        { 
            return Win32Native.CloseHandle(handle);							
        }
    }
} 
