using System;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;
using System.Security;
using Microsoft.Win32;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Versioning;
using System.Runtime.CompilerServices; 
using System.Security.Permissions;

namespace Windows
{
    [SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode=true)] 
    [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
    public abstract class SafeHandleZeroOrMinusOneIsInvalid : SafeHandle 
    {
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        protected SafeHandleZeroOrMinusOneIsInvalid(bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        { 
        }
 
        public override bool IsInvalid { 
            get { return handle == new IntPtr(-1); }
        } 
    }

    [SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode=true)] 
    [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
    public abstract class SafeHandleMinusOneIsInvalid : SafeHandle 
    { 
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        protected SafeHandleMinusOneIsInvalid(bool ownsHandle) : base(new IntPtr(-1), ownsHandle) 
        {
        }

        public override bool IsInvalid { 
            get { return handle == new IntPtr(-1); }
        } 
    }

    [SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
    [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
    public abstract class CriticalHandleZeroOrMinusOneIsInvalid : CriticalHandle
    {
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        protected CriticalHandleZeroOrMinusOneIsInvalid()
            : base(IntPtr.Zero)
        {
        }

        public override bool IsInvalid
        {
            get { return handle == new IntPtr(-1); }
        }
    }

    [SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode=true)] 
    [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode=true)]
    public abstract class CriticalHandleMinusOneIsInvalid : CriticalHandle 
    {
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        protected CriticalHandleMinusOneIsInvalid() : base(new IntPtr(-1))
        { 
        }
 
        public override bool IsInvalid { 
            get { return handle == new IntPtr(-1); }
        } 
    }


    public sealed class SafeLocalAllocHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeLocalAllocHandle() : base(true) { }
        public SafeLocalAllocHandle(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        public static SafeLocalAllocHandle InvalidHandle
        {
            get { return new SafeLocalAllocHandle(IntPtr.Zero); }
        }

        override protected bool ReleaseHandle()
        {
            return Win32Native.LocalFree(handle) == IntPtr.Zero;
        }
    }
    public sealed class SafeLsaLogonProcessHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeLsaLogonProcessHandle() : base(true) { }
        public SafeLsaLogonProcessHandle(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        public static SafeLsaLogonProcessHandle InvalidHandle
        {
            get { return new SafeLsaLogonProcessHandle(IntPtr.Zero); }
        }

        override protected bool ReleaseHandle()
        {
            return Win32Native.LsaDeregisterLogonProcess(handle) >= 0;
        }
    }
    public sealed class SafeLsaMemoryHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeLsaMemoryHandle() : base(true) { }
        public SafeLsaMemoryHandle(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        public static SafeLsaMemoryHandle InvalidHandle
        {
            get { return new SafeLsaMemoryHandle(IntPtr.Zero); }
        }

        override protected bool ReleaseHandle()
        {
            return Win32Native.LsaFreeMemory(handle) == 0;
        }
    }
    public sealed class SafeLsaPolicyHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeLsaPolicyHandle() : base(true) { }
        public SafeLsaPolicyHandle(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        public static SafeLsaPolicyHandle InvalidHandle
        {
            get { return new SafeLsaPolicyHandle(IntPtr.Zero); }
        }

        override protected bool ReleaseHandle()
        {
            return Win32Native.LsaClose(handle) == 0;
        }
    }
    public sealed class SafeLsaReturnBufferHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeLsaReturnBufferHandle() : base(true) { }
        public SafeLsaReturnBufferHandle(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        public static SafeLsaReturnBufferHandle InvalidHandle
        {
            get { return new SafeLsaReturnBufferHandle(IntPtr.Zero); }
        }

        override protected bool ReleaseHandle()
        {
            return Win32Native.LsaFreeReturnBuffer(handle) >= 0;
        }
    }
    public sealed class SafeProcessHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeProcessHandle() : base(true) { }
        public SafeProcessHandle(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        public static SafeProcessHandle InvalidHandle
        {
            get { return new SafeProcessHandle(IntPtr.Zero); }
        }

        override protected bool ReleaseHandle()
        {
            return Win32Native.CloseHandle(handle);
        }
    }
    public sealed class SafeThreadHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeThreadHandle() : base(true) { }
        public SafeThreadHandle(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        override protected bool ReleaseHandle()
        {
            return Win32Native.CloseHandle(handle);
        }
    }
    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle() : base(true) { }
        public SafeTokenHandle(IntPtr handle)
            : base(true)
        {
            SetHandle(handle);
        }

        public static SafeTokenHandle InvalidHandle
        {
            get { return new SafeTokenHandle(IntPtr.Zero); }
        }

        override protected bool ReleaseHandle()
        {
            return Win32Native.CloseHandle(handle);
        }
    }
}
