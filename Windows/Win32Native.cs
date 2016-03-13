using System;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Configuration.Assemblies;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using Microsoft.Win32;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Versioning;
using BOOL = System.Int32;
using DWORD = System.UInt32;
using ULONG = System.UInt32;

namespace Windows
{
    [SuppressUnmanagedCodeSecurityAttribute()]
    public static class Win32Native
    {
        public const int CREATE_NEW = 1,
 CREATE_ALWAYS = 2,
 OPEN_EXISTING = 3,
 OPEN_ALWAYS = 4,
 TRUNCATE_EXISTING = 5;

        public const int FILE_SHARE_READ = 0x00000001,
 FILE_SHARE_WRITE = 0x00000002,
 FILE_SHARE_DELETE = 0x00000004,
 FILE_ATTRIBUTE_READONLY = 0x00000001,
 FILE_ATTRIBUTE_HIDDEN = 0x00000002,
 FILE_ATTRIBUTE_SYSTEM = 0x00000004,
 FILE_ATTRIBUTE_DIRECTORY = 0x00000010,
 FILE_ATTRIBUTE_ARCHIVE = 0x00000020,
 FILE_ATTRIBUTE_DEVICE = 0x00000040,
 FILE_ATTRIBUTE_NORMAL = 0x00000080,
 FILE_ATTRIBUTE_TEMPORARY = 0x00000100,
 FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200,
 FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400,
 FILE_ATTRIBUTE_COMPRESSED = 0x00000800,
 FILE_ATTRIBUTE_OFFLINE = 0x00001000,
 FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,
 FILE_ATTRIBUTE_ENCRYPTED = 0x00004000,
 FILE_NOTIFY_CHANGE_FILE_NAME = 0x00000001,
 FILE_NOTIFY_CHANGE_DIR_NAME = 0x00000002,
 FILE_NOTIFY_CHANGE_ATTRIBUTES = 0x00000004,
 FILE_NOTIFY_CHANGE_SIZE = 0x00000008,
 FILE_NOTIFY_CHANGE_LAST_WRITE = 0x00000010,
 FILE_NOTIFY_CHANGE_LAST_ACCESS = 0x00000020,
 FILE_NOTIFY_CHANGE_CREATION = 0x00000040,
 FILE_NOTIFY_CHANGE_SECURITY = 0x00000100,
 FILE_ACTION_ADDED = 0x00000001,
 FILE_ACTION_REMOVED = 0x00000002,
 FILE_ACTION_MODIFIED = 0x00000003,
 FILE_ACTION_RENAMED_OLD_NAME = 0x00000004,
 FILE_ACTION_RENAMED_NEW_NAME = 0x00000005,
 FILE_CASE_SENSITIVE_SEARCH = 0x00000001,
 FILE_CASE_PRESERVED_NAMES = 0x00000002,
 FILE_UNICODE_ON_DISK = 0x00000004,
 FILE_PERSISTENT_ACLS = 0x00000008,
 FILE_FILE_COMPRESSION = 0x00000010,
 FILE_VOLUME_QUOTAS = 0x00000020,
 FILE_SUPPORTS_SPARSE_FILES = 0x00000040,
 FILE_SUPPORTS_REPARSE_POINTS = 0x00000080,
 FILE_SUPPORTS_REMOTE_STORAGE = 0x00000100,
 FILE_VOLUME_IS_COMPRESSED = 0x00008000,
 FILE_SUPPORTS_OBJECT_IDS = 0x00010000,
 FILE_SUPPORTS_ENCRYPTION = 0x00020000,
 FILE_NAMED_STREAMS = 0x00040000,
 FILE_READ_ONLY_VOLUME = 0x00080000;
#if !FEATURE_PAL
        public const int KEY_QUERY_VALUE = 0x0001;
        public const int KEY_SET_VALUE = 0x0002;
        public const int KEY_CREATE_SUB_KEY = 0x0004;
        public const int KEY_ENUMERATE_SUB_KEYS = 0x0008;
        public const int KEY_NOTIFY = 0x0010;
        public const int KEY_CREATE_LINK = 0x0020;
        public const int KEY_READ = ((STANDARD_RIGHTS_READ |
                                                           KEY_QUERY_VALUE |
                                                           KEY_ENUMERATE_SUB_KEYS |
                                                           KEY_NOTIFY)
                                                          &
                                                          (~SYNCHRONIZE));

        public const int KEY_WRITE = ((STANDARD_RIGHTS_WRITE |
                                                           KEY_SET_VALUE |
                                                           KEY_CREATE_SUB_KEY)
                                                          &
                                                          (~SYNCHRONIZE));
        public const int REG_NONE = 0;
        public const int REG_SZ = 1;
        public const int REG_EXPAND_SZ = 2;
        public const int REG_BINARY = 3;
        public const int REG_DWORD = 4;
        public const int REG_DWORD_LITTLE_ENDIAN = 4;
        public const int REG_DWORD_BIG_ENDIAN = 5;
        public const int REG_LINK = 6;
        public const int REG_MULTI_SZ = 7;
        public const int REG_RESOURCE_LIST = 8;
        public const int REG_FULL_RESOURCE_DESCRIPTOR = 9;
        public const int REG_RESOURCE_REQUIREMENTS_LIST = 10;
        public const int REG_QWORD = 11;

        public const int HWND_BROADCAST = 0xffff;
        public const int WM_SETTINGCHANGE = 0x001A;

        public const uint CRYPTPROTECTMEMORY_BLOCK_SIZE = 16;
        public const uint CRYPTPROTECTMEMORY_SAME_PROCESS = 0x00;
        public const uint CRYPTPROTECTMEMORY_CROSS_PROCESS = 0x01;
        public const uint CRYPTPROTECTMEMORY_SAME_LOGON = 0x02;
        public const int SECURITY_ANONYMOUS = ((int)SECURITY_IMPERSONATION_LEVEL.Anonymous << 16);
        public const int SECURITY_SQOS_PRESENT = 0x00100000;
        public const string MICROSOFT_KERBEROS_NAME = "Kerberos";
        public const uint ANONYMOUS_LOGON_LUID = 0x3e6;

        public const int SECURITY_ANONYMOUS_LOGON_RID = 0x00000007;
        public const int SECURITY_AUTHENTICATED_USER_RID = 0x0000000B;
        public const int SECURITY_LOCAL_SYSTEM_RID = 0x00000012;
        public const int SECURITY_BUILTIN_DOMAIN_RID = 0x00000020;
        public const int DOMAIN_USER_RID_GUEST = 0x000001F5;

        public const uint SE_PRIVILEGE_DISABLED = 0x00000000;
        public const uint SE_PRIVILEGE_ENABLED_BY_DEFAULT = 0x00000001;
        public const uint SE_PRIVILEGE_ENABLED = 0x00000002;
        public const uint SE_PRIVILEGE_USED_FOR_ACCESS = 0x80000000;

        public const uint SE_GROUP_MANDATORY = 0x00000001;
        public const uint SE_GROUP_ENABLED_BY_DEFAULT = 0x00000002;
        public const uint SE_GROUP_ENABLED = 0x00000004;
        public const uint SE_GROUP_OWNER = 0x00000008;
        public const uint SE_GROUP_USE_FOR_DENY_ONLY = 0x00000010;
        public const uint SE_GROUP_LOGON_ID = 0xC0000000;
        public const uint SE_GROUP_RESOURCE = 0x20000000;

        public const uint DUPLICATE_CLOSE_SOURCE = 0x00000001;
        public const uint DUPLICATE_SAME_ACCESS = 0x00000002;
        public const uint DUPLICATE_SAME_ATTRIBUTES = 0x00000004;
#endif
        public const int READ_CONTROL = 0x00020000;
        public const int SYNCHRONIZE = 0x00100000;

        public const int STANDARD_RIGHTS_READ = READ_CONTROL;
        public const int STANDARD_RIGHTS_WRITE = READ_CONTROL;

        // STANDARD_RIGHTS_REQUIRED  (0x000F0000L)
        // SEMAPHORE_ALL_ACCESS          (STANDARD_RIGHTS_REQUIRED|SYNCHRONIZE|0x3)

        // SEMAPHORE and Event both use 0x0002 
        // MUTEX uses 0x001 (MUTANT_QUERY_STATE)

        // Note that you may need to specify the SYNCHRONIZE bit as well 
        // to be able to open a synchronization primitive.
        public const int SEMAPHORE_MODIFY_STATE = 0x00000002;
        public const int EVENT_MODIFY_STATE = 0x00000002;
        public const int MUTEX_MODIFY_STATE = 0x00000001;
        public const int MUTEX_ALL_ACCESS = 0x001F0001;


        public const uint GENERIC_READ = 0x80000000;
        public const int GENERIC_WRITE = 0x40000000;
        public const int GENERIC_EXECUTE = 0x20000000;
        public const int GENERIC_ALL = 0x10000000;

        public const int LMEM_FIXED = 0x0000;
        public const int LMEM_ZEROINIT = 0x0040;
        public const int LPTR = (LMEM_FIXED | LMEM_ZEROINIT);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class OSVERSIONINFO
        {
            public OSVERSIONINFO()
            {
                OSVersionInfoSize = (int)Marshal.SizeOf(this);
            }
            public int OSVersionInfoSize = 0;
            public int MajorVersion = 0;
            public int MinorVersion = 0;
            public int BuildNumber = 0;
            public int PlatformId = 0;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public String CSDVersion = null;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class OSVERSIONINFOEX
        {

            public OSVERSIONINFOEX()
            {
                OSVersionInfoSize = (int)Marshal.SizeOf(this);
            }
            public int OSVersionInfoSize = 0;
            public int MajorVersion = 0;
            public int MinorVersion = 0;
            public int BuildNumber = 0;
            public int PlatformId = 0;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string CSDVersion = null;
            public ushort ServicePackMajor = 0;
            public ushort ServicePackMinor = 0;
            public short SuiteMask = 0;
            public byte ProductType = 0;
            public byte Reserved = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_INFO
        {
            public int dwOemId;
            public int dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public IntPtr dwActiveProcessorMask;
            public int dwNumberOfProcessors;
            public int dwProcessorType;
            public int dwAllocationGranularity;
            public short wProcessorLevel;
            public short wProcessorRevision;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class SECURITY_ATTRIBUTES
        {
            public int nLength = 0;
            public unsafe byte* pSecurityDescriptor = null;
            public int bInheritHandle = 0;
        }

        [StructLayout(LayoutKind.Sequential), Serializable]
        public struct WIN32_FILE_ATTRIBUTE_DATA
        {
            public int fileAttributes;
            public uint ftCreationTimeLow;
            public uint ftCreationTimeHigh;
            public uint ftLastAccessTimeLow;
            public uint ftLastAccessTimeHigh;
            public uint ftLastWriteTimeLow;
            public uint ftLastWriteTimeHigh;
            public int fileSizeHigh;
            public int fileSizeLow;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FILE_TIME
        {
            public FILE_TIME(long fileTime)
            {
                ftTimeLow = (uint)fileTime;
                ftTimeHigh = (uint)(fileTime >> 32);
            }

            public long ToTicks()
            {
                return ((long)ftTimeHigh << 32) + ftTimeLow;
            }

            public uint ftTimeLow;
            public uint ftTimeHigh;
        }

#if !FEATURE_PAL

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct KERB_S4U_LOGON
        {
            public uint MessageType;
            public uint Flags;
            public UNICODE_INTPTR_STRING ClientUpn;   // REQUIRED: UPN for client 
            public UNICODE_INTPTR_STRING ClientRealm; // Optional: Client Realm, if known
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct LSA_OBJECT_ATTRIBUTES
        {
            public int Length;
            public IntPtr RootDirectory;
            public IntPtr ObjectName;
            public int Attributes;
            public IntPtr SecurityDescriptor;
            public IntPtr SecurityQualityOfService;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct UNICODE_STRING
        {
            public ushort Length;
            public ushort MaximumLength;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string Buffer;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct UNICODE_INTPTR_STRING
        {
            public UNICODE_INTPTR_STRING(int length, int maximumLength, IntPtr buffer)
            {
                this.Length = (ushort)length;
                this.MaxLength = (ushort)maximumLength;
                this.Buffer = buffer;
            }
            public ushort Length;
            public ushort MaxLength;
            public IntPtr Buffer;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LSA_TRANSLATED_NAME
        {
            public int Use;
            public UNICODE_INTPTR_STRING Name;
            public int DomainIndex;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct LSA_TRANSLATED_SID
        {
            public int Use;
            public uint Rid;
            public int DomainIndex;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct LSA_TRANSLATED_SID2
        {
            public int Use;
            public IntPtr Sid;
            public int DomainIndex;
            uint Flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LSA_TRUST_INFORMATION
        {
            public UNICODE_INTPTR_STRING Name;
            public IntPtr Sid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LSA_REFERENCED_DOMAIN_LIST
        {
            public int Entries;
            public IntPtr Domains;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct LUID
        {
            public uint LowPart;
            public uint HighPart;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct LUID_AND_ATTRIBUTES
        {
            public LUID Luid;
            public uint Attributes;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct QUOTA_LIMITS
        {
            public IntPtr PagedPoolLimit;
            public IntPtr NonPagedPoolLimit;
            public IntPtr MinimumWorkingSetSize;
            public IntPtr MaximumWorkingSetSize;
            public IntPtr PagefileLimit;
            public IntPtr TimeLimit;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SECURITY_LOGON_SESSION_DATA
        {
            public uint Size;
            public LUID LogonId;
            public UNICODE_INTPTR_STRING UserName;
            public UNICODE_INTPTR_STRING LogonDomain;
            public UNICODE_INTPTR_STRING AuthenticationPackage;
            public uint LogonType;
            public uint Session;
            public IntPtr Sid;
            public long LogonTime;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SID_AND_ATTRIBUTES
        {
            public IntPtr Sid;
            public uint Attributes;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TOKEN_GROUPS
        {
            public uint GroupCount;
            public SID_AND_ATTRIBUTES Groups;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TOKEN_PRIVILEGE
        {
            public uint PrivilegeCount;
            public LUID_AND_ATTRIBUTES Privilege;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TOKEN_SOURCE
        {
            private const int TOKEN_SOURCE_LENGTH = 8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = TOKEN_SOURCE_LENGTH)]
            public char[] Name;
            public LUID SourceIdentifier;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TOKEN_STATISTICS
        {
            public LUID TokenId;
            public LUID AuthenticationId;
            public long ExpirationTime;
            public uint TokenType;
            public uint ImpersonationLevel;
            public uint DynamicCharged;
            public uint DynamicAvailable;
            public uint GroupCount;
            public uint PrivilegeCount;
            public LUID ModifiedId;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TOKEN_USER
        {
            public SID_AND_ATTRIBUTES User;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MEMORYSTATUSEX
        {
            public MEMORYSTATUSEX()
            {
                length = (int)Marshal.SizeOf(this);
            }
            public int length;
            public int memoryLoad;
            public ulong totalPhys;
            public ulong availPhys;
            public ulong totalPageFile;
            public ulong availPageFile;
            public ulong totalVirtual;
            public ulong availVirtual;
            public ulong availExtendedVirtual;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MEMORYSTATUS
        {
            public MEMORYSTATUS()
            {
                length = (int)Marshal.SizeOf(this);
            }

            public int length;
            public int memoryLoad;
            public uint totalPhys;
            public uint availPhys;
            public uint totalPageFile;
            public uint availPageFile;
            public uint totalVirtual;
            public uint availVirtual;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MEMORY_BASIC_INFORMATION
        {
            public void* BaseAddress;
            public void* AllocationBase;
            public uint AllocationProtect;
            public UIntPtr RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }
#endif

#if !FEATURE_PAL
        public const String KERNEL32 = "kernel32.dll";
        public const String USER32 = "user32.dll";
        public const String ADVAPI32 = "advapi32.dll";
        public const String OLE32 = "ole32.dll";
        public const String OLEAUT32 = "oleaut32.dll";
        public const String SHFOLDER = "shfolder.dll";
        public const String SHIM = "mscoree.dll";
        public const String CRYPT32 = "crypt32.dll";
        public const String SECUR32 = "secur32.dll";
        public const String MSCORWKS = "mscorwks.dll";

#else 
 
#if !PLATFORM_UNIX 
        public const String DLLPREFIX = "";
        public const String DLLSUFFIX = ".dll"; 
#else
#if __APPLE__
        public const String DLLPREFIX = "lib";
        public const String DLLSUFFIX = ".dylib"; 
#elif _AIX
        public const String DLLPREFIX = "lib"; 
        public const String DLLSUFFIX = ".a"; 
#elif __hppa__ || IA64
        public const String DLLPREFIX = "lib"; 
        public const String DLLSUFFIX = ".sl";
#else
        public const String DLLPREFIX = "lib";
        public const String DLLSUFFIX = ".so"; 
#endif
#endif 
 
        public const String KERNEL32 = DLLPREFIX + "rotor_pal" + DLLSUFFIX;
        public const String USER32   = DLLPREFIX + "rotor_pal" + DLLSUFFIX; 
        public const String ADVAPI32 = DLLPREFIX + "rotor_pal" + DLLSUFFIX;
        public const String OLE32    = DLLPREFIX + "rotor_pal" + DLLSUFFIX;
        public const String OLEAUT32 = DLLPREFIX + "rotor_palrt" + DLLSUFFIX;
        public const String SHIM     = DLLPREFIX + "sscoree" + DLLSUFFIX; 
        public const String MSCORWKS = DLLPREFIX + "mscorwks" + DLLSUFFIX;
 
#endif // !FEATURE_PAL

        public const String LSTRCPY = "lstrcpy";
        public const String LSTRCPYN = "lstrcpyn";
        public const String LSTRLEN = "lstrlen";
        public const String LSTRLENA = "lstrlenA";
        public const String LSTRLENW = "lstrlenW";
        public const String MOVEMEMORY = "RtlMoveMemory";

        public const int SEM_FAILCRITICALERRORS = 1;

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern void SetLastError(int errorCode);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetVersionEx([In, Out] OSVERSIONINFO ver);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetVersionEx([In, Out] OSVERSIONINFOEX ver);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern void GetSystemInfo(ref SYSTEM_INFO lpSystemInfo);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, BestFitMapping = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int FormatMessage(int dwFlags, IntPtr lpSource,
                    int dwMessageId, int dwLanguageId, StringBuilder lpBuffer,
                    int nSize, IntPtr va_list_arguments);

        public static String GetMessage(int errorCode)
        {
            StringBuilder sb = new StringBuilder(512);
            int result = Win32Native.FormatMessage(FORMAT_MESSAGE_IGNORE_INSERTS |
                FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_ARGUMENT_ARRAY,
                Win32Native.NULL, errorCode, 0, sb, sb.Capacity, Win32Native.NULL);
            if (result != 0)
            {
                String s = sb.ToString();
                return s;
            }
            else
            {
                return "UnknownError_Num";
            }
        }

        [DllImport(KERNEL32, EntryPoint = "LocalAlloc")]
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static extern IntPtr LocalAlloc_NoSafeHandle(int uFlags, IntPtr sizetdwBytes);

#if !FEATURE_PAL
        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        SafeLocalAllocHandle LocalAlloc(
            [In] int uFlags,
            [In] IntPtr sizetdwBytes);
#endif

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern IntPtr LocalFree(IntPtr handle);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern void ZeroMemory(IntPtr handle, uint length);

#if !FEATURE_PAL
        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX buffer);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GlobalMemoryStatus([In, Out] MEMORYSTATUS buffer);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        unsafe public static extern IntPtr VirtualQuery(void* address, ref MEMORY_BASIC_INFORMATION buffer, IntPtr sizeOfBuffer);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        unsafe public static extern void* VirtualAlloc(void* address, UIntPtr numBytes, int commitOrReserve, int pageProtectionMode);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        unsafe public static extern bool VirtualFree(void* address, UIntPtr numBytes, int pageFreeMode);

#if IO_CANCELLATION_ENABLED 
        [DllImport(KERNEL32, CharSet=CharSet.Auto, BestFitMapping=false, SetLastError=true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, String methodName); 

        [DllImport(KERNEL32, CharSet=CharSet.Auto, BestFitMapping=false, SetLastError=true, BestFitMapping=false)] 
        [ResourceExposure(ResourceScope.Process)]  // Is your module side-by-side? 
        public static extern IntPtr GetModuleHandle(String moduleName);
#endif
#endif

        [DllImport(KERNEL32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern uint GetTempPath(int bufferLen, StringBuilder buffer);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, EntryPoint = LSTRCPY, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr lstrcpy(IntPtr dst, String src);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, EntryPoint = LSTRCPY, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr lstrcpy(StringBuilder dst, IntPtr src);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, EntryPoint = LSTRLEN)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int lstrlen(sbyte[] ptr);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, EntryPoint = LSTRLEN)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int lstrlen(IntPtr ptr);

        [DllImport(KERNEL32, CharSet = CharSet.Ansi, EntryPoint = LSTRLENA)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int lstrlenA(IntPtr ptr);

        [DllImport(KERNEL32, CharSet = CharSet.Unicode, EntryPoint = LSTRLENW)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int lstrlenW(IntPtr ptr);

        [DllImport(Win32Native.OLEAUT32, CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static extern IntPtr SysAllocStringLen(String src, int len);  // BSTR 

        [DllImport(Win32Native.OLEAUT32)]
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern int SysStringLen(IntPtr bstr);

        [DllImport(Win32Native.OLEAUT32)]
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern void SysFreeString(IntPtr bstr);

        [DllImport(KERNEL32, CharSet = CharSet.Unicode, EntryPoint = MOVEMEMORY)]
        [ResourceExposure(ResourceScope.None)]
        public static extern void CopyMemoryUni(IntPtr pdst, String psrc, IntPtr sizetcb);

        [DllImport(KERNEL32, CharSet = CharSet.Unicode, EntryPoint = MOVEMEMORY)]
        [ResourceExposure(ResourceScope.None)]
        public static extern void CopyMemoryUni(StringBuilder pdst,
                    IntPtr psrc, IntPtr sizetcb);

        [DllImport(KERNEL32, CharSet = CharSet.Ansi, EntryPoint = MOVEMEMORY, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern void CopyMemoryAnsi(IntPtr pdst, String psrc, IntPtr sizetcb);

        [DllImport(KERNEL32, CharSet = CharSet.Ansi, EntryPoint = MOVEMEMORY, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern void CopyMemoryAnsi(StringBuilder pdst,
                    IntPtr psrc, IntPtr sizetcb);


        [DllImport(KERNEL32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetACP();

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool SetEvent(SafeWaitHandle handle);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool ResetEvent(SafeWaitHandle handle);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern DWORD WaitForMultipleObjects(DWORD nCount, IntPtr[] handles, bool bWaitAll, DWORD dwMilliseconds);


        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)] // Machine or none based on the value of "name" 
        public static extern SafeWaitHandle CreateEvent(SECURITY_ATTRIBUTES lpSecurityAttributes, bool isManualReset, bool initialState, String name);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern SafeWaitHandle OpenEvent(/* DWORD */ int desiredAccess, bool inheritHandle, String name);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static extern SafeWaitHandle CreateMutex(SECURITY_ATTRIBUTES lpSecurityAttributes, bool initialOwner, String name);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern SafeWaitHandle OpenMutex(/* DWORD */ int desiredAccess, bool inheritHandle, String name);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public static extern bool ReleaseMutex(SafeWaitHandle handle);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int GetFullPathName([In] char[] path, int numBufferChars, [Out] char[] buffer, IntPtr mustBeZero);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public unsafe static extern int GetFullPathName(char* path, int numBufferChars, char* buffer, IntPtr mustBeZero);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int GetLongPathName(String path, StringBuilder longPathBuffer, int bufferLength);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int GetLongPathName([In] char[] path, [Out] char[] longPathBuffer, int bufferLength);


        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public unsafe static extern int GetLongPathName(char* path, char* longPathBuffer, int bufferLength);

        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)]
        public static SafeFileHandle SafeCreateFile(String lpFileName,
                    int dwDesiredAccess, System.IO.FileShare dwShareMode,
                    SECURITY_ATTRIBUTES securityAttrs, System.IO.FileMode dwCreationDisposition,
                    int dwFlagsAndAttributes, IntPtr hTemplateFile)
        {
            SafeFileHandle handle = CreateFile(lpFileName, dwDesiredAccess, dwShareMode,
                                securityAttrs, dwCreationDisposition,
                                dwFlagsAndAttributes, hTemplateFile);

            if (!handle.IsInvalid)
            {
                int fileType = Win32Native.GetFileType(handle);
                if (fileType != Win32Native.FILE_TYPE_DISK)
                {
                    handle.Dispose();
                    throw new NotSupportedException("NotSupported_FileStreamOnNonFiles");
                }
            }

            return handle;
        }

        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)]
        public static SafeFileHandle UnsafeCreateFile(String lpFileName,
                    int dwDesiredAccess, System.IO.FileShare dwShareMode,
                    SECURITY_ATTRIBUTES securityAttrs, System.IO.FileMode dwCreationDisposition,
                    int dwFlagsAndAttributes, IntPtr hTemplateFile)
        {
            SafeFileHandle handle = CreateFile(lpFileName, dwDesiredAccess, dwShareMode,
                                securityAttrs, dwCreationDisposition,
                                dwFlagsAndAttributes, hTemplateFile);

            return handle;
        }

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern SafeFileHandle CreateFile(String lpFileName,
                    int dwDesiredAccess, System.IO.FileShare dwShareMode,
                    SECURITY_ATTRIBUTES securityAttrs, System.IO.FileMode dwCreationDisposition,
                    int dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern IntPtr CreateFile(String lpFileName,
                    int dwDesiredAccess, int dwShareMode,
                    SECURITY_ATTRIBUTES securityAttrs, int dwCreationDisposition,
                    int dwFlagsAndAttributes, IntPtr hTemplateFile);


        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern SafeFileMappingHandle CreateFileMapping(SafeFileHandle hFile, IntPtr lpAttributes, uint fProtect, uint dwMaximumSizeHigh, uint dwMaximumSizeLow, String lpName);

        [DllImport(KERNEL32, SetLastError = true, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern IntPtr MapViewOfFile(
            SafeFileMappingHandle handle, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, UIntPtr dwNumerOfBytesToMap);

        [DllImport(KERNEL32, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.Machine)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Machine)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport(KERNEL32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetFileType(SafeFileHandle handle);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool SetEndOfFile(SafeFileHandle hFile);

        [DllImport(KERNEL32, SetLastError = true, EntryPoint = "SetFilePointer")]
        [ResourceExposure(ResourceScope.None)]
        public unsafe static extern int SetFilePointerWin32(SafeFileHandle handle, int lo, int* hi, int origin);

        [DllImport(KERNEL32, SetLastError = true, EntryPoint = "SetFilePointer")]
        [ResourceExposure(ResourceScope.None)]
        public unsafe static extern int SetFilePointerWin32(IntPtr handle, int lo, int* hi, int origin);

        [DllImport(KERNEL32, SetLastError = true, EntryPoint = "SetFilePointer")]
        [ResourceExposure(ResourceScope.None)]
        public static extern int SetFilePointer(IntPtr handle, int lo, int hi, int origin);


        [ResourceExposure(ResourceScope.None)]
        public unsafe static long SetFilePointer(SafeFileHandle handle, long offset, System.IO.SeekOrigin origin, out int hr)
        {
            hr = 0;
            int lo = (int)offset;
            int hi = (int)(offset >> 32);
            lo = SetFilePointerWin32(handle, lo, &hi, (int)origin);

            if (lo == -1 && ((hr = Marshal.GetLastWin32Error()) != 0))
                return -1;
            return (long)(((ulong)((uint)hi)) << 32) | ((uint)lo);
        }

        [ResourceExposure(ResourceScope.None)]
        public unsafe static long SetFilePointer(IntPtr handle, long offset, int origin, out int hr)
        {
            hr = 0;
            int lo = (int)offset;
            int hi = (int)(offset >> 32);
            lo = SetFilePointerWin32(handle, lo, &hi, (int)origin);

            if (lo == -1 && ((hr = Marshal.GetLastWin32Error()) != 0))
                return -1;
            return (long)(((ulong)((uint)hi)) << 32) | ((uint)lo);
        }


        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        unsafe public static extern int ReadFile(SafeFileHandle handle, byte* bytes, int numBytesToRead, IntPtr numBytesRead_mustBeZero, NativeOverlapped* overlapped);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        unsafe public static extern int ReadFile(SafeFileHandle handle, byte* bytes, int numBytesToRead, out int numBytesRead, IntPtr mustBeZero);


        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static unsafe extern int WriteFile(SafeFileHandle handle, byte* bytes, int numBytesToWrite, IntPtr numBytesWritten_mustBeZero, NativeOverlapped* lpOverlapped);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static unsafe extern int WriteFile(SafeFileHandle handle, byte* bytes, int numBytesToWrite, out int numBytesWritten, IntPtr mustBeZero);

#if IO_CANCELLATION_ENABLED
        [DllImport(KERNEL32, SetLastError=true)] 
        [ResourceExposure(ResourceScope.Process)] 
        public static extern bool CancelSynchronousIo(IntPtr threadHandle);
 
        [DllImport(KERNEL32, SetLastError=true)]
        [ResourceExposure(ResourceScope.Process)]
        public static unsafe extern bool CancelIoEx(SafeFileHandle handle, NativeOverlapped* lpOverlapped);
#endif
        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetDiskFreeSpaceEx(String drive, out long freeBytesForUser, out long totalBytes, out long freeBytes);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetDriveType(String drive);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetVolumeInformation(String drive, StringBuilder volumeName, int volumeNameBufLen, out int volSerialNumber, out int maxFileNameLen, out int fileSystemFlags, StringBuilder fileSystemName, int fileSystemNameBufLen);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool SetVolumeLabel(String driveLetter, String volumeName);

#if !FEATURE_PAL
        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int GetWindowsDirectory(StringBuilder sb, int length);

        public const int LCMAP_SORTKEY = 0x00000400;
        [DllImport(KERNEL32, CharSet = CharSet.Unicode, ExactSpelling = true)]

        [ResourceExposure(ResourceScope.None)]
        public static unsafe extern int LCMapStringW(int lcid, int flags, char* src, int cchSrc, char* target, int cchTarget);

        public const int FIND_STARTSWITH = 0x00100000;
        public const int FIND_ENDSWITH = 0x00200000;
        public const int FIND_FROMSTART = 0x00400000;
        public const int FIND_FROMEND = 0x00800000;


        [DllImport(KERNEL32, CharSet = CharSet.Unicode, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.None)]
        public static unsafe extern int FindNLSString(int Locale, int dwFindFlags, char* lpStringSource, int cchSource, char* lpStringValue, int cchValue, IntPtr pcchFound); // , out int pcchFound); 
#endif

#if !FEATURE_PAL
        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int GetSystemDirectory(StringBuilder sb, int length);
#else
        [DllImport(KERNEL32, CharSet=CharSet.Unicode, SetLastError=true, EntryPoint="PAL_GetPALDirectoryW", BestFitMapping=false)]
        [ResourceExposure(ResourceScope.Machine)] 
        public static extern int GetSystemDirectory(StringBuilder sb, int length);
 
        [DllImport(OLEAUT32, CharSet=CharSet.Unicode, SetLastError=true, EntryPoint="PAL_FetchConfigurationStringW")] 
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool FetchConfigurationString(bool perMachine, String parameterName, StringBuilder parameterValue, int parameterValueLength); 
#endif

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public unsafe static extern bool SetFileTime(SafeFileHandle hFile, FILE_TIME* creationTime,
                    FILE_TIME* lastAccessTime, FILE_TIME* lastWriteTime);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetFileSize(SafeFileHandle hFile, out int highSize);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetFileSize(IntPtr hFile, out int highSize);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetFileSize(IntPtr hFile, IntPtr highSize);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool LockFile(SafeFileHandle handle, int offsetLow, int offsetHigh, int countLow, int countHigh);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool UnlockFile(SafeFileHandle handle, int offsetLow, int offsetHigh, int countLow, int countHigh);

        public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        public static readonly IntPtr NULL = IntPtr.Zero;

        public const int STD_INPUT_HANDLE = -10;
        public const int STD_OUTPUT_HANDLE = -11;
        public const int STD_ERROR_HANDLE = -12;

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        public const int CTRL_C_EVENT = 0;
        public const int CTRL_BREAK_EVENT = 1;
        public const int CTRL_CLOSE_EVENT = 2;
        public const int CTRL_LOGOFF_EVENT = 5;
        public const int CTRL_SHUTDOWN_EVENT = 6;
        public const short KEY_EVENT = 1;

        public const int FILE_TYPE_DISK = 0x0001;
        public const int FILE_TYPE_CHAR = 0x0002;
        public const int FILE_TYPE_PIPE = 0x0003;

        public const int REPLACEFILE_WRITE_THROUGH = 0x1;
        public const int REPLACEFILE_IGNORE_MERGE_ERRORS = 0x2;

        private const int FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
        private const int FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
        private const int FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000;

        public const int IO_REPARSE_TAG_MOUNT_POINT = unchecked((int)0xA0000003);

        public const int PAGE_READWRITE = 0x04;

        public const int MEM_COMMIT = 0x1000;
        public const int MEM_RESERVE = 0x2000;
        public const int MEM_RELEASE = 0x8000;
        public const int MEM_FREE = 0x10000;

        public const int ERROR_SUCCESS = 0x0;
        public const int ERROR_INVALID_FUNCTION = 0x1;
        public const int ERROR_FILE_NOT_FOUND = 0x2;
        public const int ERROR_PATH_NOT_FOUND = 0x3;
        public const int ERROR_ACCESS_DENIED = 0x5;
        public const int ERROR_INVALID_HANDLE = 0x6;
        public const int ERROR_NOT_ENOUGH_MEMORY = 0x8;
        public const int ERROR_INVALID_DATA = 0xd;
        public const int ERROR_INVALID_DRIVE = 0xf;
        public const int ERROR_NO_MORE_FILES = 0x12;
        public const int ERROR_NOT_READY = 0x15;
        public const int ERROR_BAD_LENGTH = 0x18;
        public const int ERROR_SHARING_VIOLATION = 0x20;
        public const int ERROR_NOT_SUPPORTED = 0x32;
        public const int ERROR_FILE_EXISTS = 0x50;
        public const int ERROR_INVALID_PARAMETER = 0x57;
        public const int ERROR_CALL_NOT_IMPLEMENTED = 0x78;
        public const int ERROR_INSUFFICIENT_BUFFER = 0x7A;
        public const int ERROR_INVALID_NAME = 0x7B;
        public const int ERROR_BAD_PATHNAME = 0xA1;
        public const int ERROR_ALREADY_EXISTS = 0xB7;
        public const int ERROR_ENVVAR_NOT_FOUND = 0xCB;
        public const int ERROR_FILENAME_EXCED_RANGE = 0xCE;
        public const int ERROR_NO_DATA = 0xE8;
        public const int ERROR_PIPE_NOT_CONNECTED = 0xE9;
        public const int ERROR_MORE_DATA = 0xEA;
        public const int ERROR_OPERATION_ABORTED = 0x3E3;
        public const int ERROR_NO_TOKEN = 0x3f0;
        public const int ERROR_DLL_INIT_FAILED = 0x45A;
        public const int ERROR_NON_ACCOUNT_SID = 0x4E9;
        public const int ERROR_NOT_ALL_ASSIGNED = 0x514;
        public const int ERROR_UNKNOWN_REVISION = 0x519;
        public const int ERROR_INVALID_OWNER = 0x51B;
        public const int ERROR_INVALID_PRIMARY_GROUP = 0x51C;
        public const int ERROR_NO_SUCH_PRIVILEGE = 0x521;
        public const int ERROR_PRIVILEGE_NOT_HELD = 0x522;
        public const int ERROR_NONE_MAPPED = 0x534;
        public const int ERROR_INVALID_ACL = 0x538;
        public const int ERROR_INVALID_SID = 0x539;
        public const int ERROR_INVALID_SECURITY_DESCR = 0x53A;
        public const int ERROR_BAD_IMPERSONATION_LEVEL = 0x542;
        public const int ERROR_CANT_OPEN_ANONYMOUS = 0x543;
        public const int ERROR_NO_SECURITY_ON_OBJECT = 0x546;
        public const int ERROR_TRUSTED_RELATIONSHIP_FAILURE = 0x6FD;

        public const uint STATUS_SUCCESS = 0x00000000;
        public const uint STATUS_SOME_NOT_MAPPED = 0x00000107;
        public const uint STATUS_NO_MEMORY = 0xC0000017;
        public const uint STATUS_OBJECT_NAME_NOT_FOUND = 0xC0000034;
        public const uint STATUS_NONE_MAPPED = 0xC0000073;
        public const uint STATUS_INSUFFICIENT_RESOURCES = 0xC000009A;
        public const uint STATUS_ACCESS_DENIED = 0xC0000022;

        public const int INVALID_FILE_SIZE = -1;

        public const int STATUS_ACCOUNT_RESTRICTION = unchecked((int)0xC000006E);

        public static int MakeHRFromErrorCode(int errorCode)
        {
            return unchecked(((int)0x80070000) | errorCode);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto), Serializable]
        [BestFitMapping(false)]
        public class WIN32_FIND_DATA
        {
            public int dwFileAttributes = 0;
            public int ftCreationTime_dwLowDateTime = 0;
            public int ftCreationTime_dwHighDateTime = 0;
            public int ftLastAccessTime_dwLowDateTime = 0;
            public int ftLastAccessTime_dwHighDateTime = 0;
            public int ftLastWriteTime_dwLowDateTime = 0;
            public int ftLastWriteTime_dwHighDateTime = 0;
            public int nFileSizeHigh = 0;
            public int nFileSizeLow = 0;
            public int dwReserved0 = 0;
            public int dwReserved1 = 0;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public String cFileName = null;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public String cAlternateFileName = null;
        }

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool CopyFile(
                    String src, String dst, bool failIfExists);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool CreateDirectory(
                    String path, SECURITY_ATTRIBUTES lpSecurityAttributes);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool DeleteFile(String path);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool ReplaceFile(String replacedFileName, String replacementFileName, String backupFileName, int dwReplaceFlags, IntPtr lpExclude, IntPtr lpReserved);

        [DllImport(ADVAPI32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool DecryptFile(String path, int reservedMustBeZero);

        [DllImport(ADVAPI32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool EncryptFile(String path);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern SafeFindHandle FindFirstFile(String fileName, [In, Out] Win32Native.WIN32_FIND_DATA data);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool FindNextFile(
                    SafeFindHandle hndFindFile,
                    [In, Out, MarshalAs(UnmanagedType.LPStruct)] 
                    WIN32_FIND_DATA lpFindFileData);

        [DllImport(KERNEL32)]
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern bool FindClose(IntPtr handle);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int GetCurrentDirectory(
                  int nBufferLength,
                  StringBuilder lpBuffer);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetFileAttributesEx(String name, int fileInfoLevel, ref WIN32_FILE_ATTRIBUTE_DATA lpFileInformation);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetFileAttributes(String name);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool SetFileAttributes(String name, int attr);

#if !PLATFORM_UNIX
        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetLogicalDrives();
#endif

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern uint GetTempFileName(String tmpPath, String prefix, uint uniqueIdOrZero, StringBuilder tmpFileName);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool MoveFile(String src, String dst);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool DeleteVolumeMountPoint(String mountPoint);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool RemoveDirectory(String path);

        [DllImport(KERNEL32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern bool SetCurrentDirectory(String path);

        [DllImport(KERNEL32, SetLastError = false)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern int SetErrorMode(int newMode);

        public const int LCID_SUPPORTED = 0x00000002;

        [DllImport(KERNEL32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern unsafe int WideCharToMultiByte(uint cp, uint flags, char* pwzSource, int cchSource, byte* pbDestBuffer, int cbDestBuffer, IntPtr null1, IntPtr null2);

        public delegate bool ConsoleCtrlHandlerRoutine(int controlType);

        [DllImport(KERNEL32, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool SetConsoleCtrlHandler(ConsoleCtrlHandlerRoutine handler, bool addOrRemove);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool SetEnvironmentVariable(string lpName, string lpValue);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int GetEnvironmentVariable(string lpName, StringBuilder lpValue, int size);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern uint GetCurrentProcessId();

        [DllImport(ADVAPI32, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetUserName(StringBuilder lpBuffer, ref int nSize);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, BestFitMapping = false)]
        public extern static int GetComputerName(StringBuilder nameBuffer, ref int bufferSize);

#if FEATURE_COMINTEROP
        [DllImport(Win32Native.OLE32)]
        [ResourceExposure(ResourceScope.None)] 
        public static extern IntPtr CoTaskMemAlloc(int cb);
 
        [DllImport(Win32Native.OLE32)] 
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr CoTaskMemRealloc(IntPtr pv, int cb); 

        [DllImport(Win32Native.OLE32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern void CoTaskMemFree(IntPtr ptr); 
#endif

#if !FEATURE_PAL
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct SMALL_RECT
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct CONSOLE_SCREEN_BUFFER_INFO
        {
            public COORD dwSize;
            public COORD dwCursorPosition;
            public short wAttributes;
            public SMALL_RECT srWindow;
            public COORD dwMaximumWindowSize;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct CONSOLE_CURSOR_INFO
        {
            public int dwSize;
            public bool bVisible;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct KeyEventRecord
        {
            public bool keyDown;
            public short repeatCount;
            public short virtualKeyCode;
            public short virtualScanCode;
            public char uChar;
            public int controlKeyState;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct InputRecord
        {
            public short eventType;
            public KeyEventRecord keyEvent;
        }

        [Flags, Serializable]
        public enum Color : short
        {
            Black = 0,
            ForegroundBlue = 0x1,
            ForegroundGreen = 0x2,
            ForegroundRed = 0x4,
            ForegroundYellow = 0x6,
            ForegroundIntensity = 0x8,
            BackgroundBlue = 0x10,
            BackgroundGreen = 0x20,
            BackgroundRed = 0x40,
            BackgroundYellow = 0x60,
            BackgroundIntensity = 0x80,

            ForegroundMask = 0xf,
            BackgroundMask = 0xf0,
            ColorMask = 0xff
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CHAR_INFO
        {
            ushort charData;
            short attributes;
        }

        public const int ENABLE_PROCESSED_INPUT = 0x0001;
        public const int ENABLE_LINE_INPUT = 0x0002;
        public const int ENABLE_ECHO_INPUT = 0x0004;

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool GetConsoleMode(IntPtr hConsoleHandle, out int mode);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool Beep(int frequency, int duration);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetConsoleScreenBufferInfo(IntPtr hConsoleOutput,
            out CONSOLE_SCREEN_BUFFER_INFO lpConsoleScreenBufferInfo);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool SetConsoleScreenBufferSize(IntPtr hConsoleOutput, COORD size);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern COORD GetLargestConsoleWindowSize(IntPtr hConsoleOutput);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool FillConsoleOutputCharacter(IntPtr hConsoleOutput,
            char character, int nLength, COORD dwWriteCoord, out int pNumCharsWritten);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool FillConsoleOutputAttribute(IntPtr hConsoleOutput,
            short wColorAttribute, int numCells, COORD startCoord, out int pNumBytesWritten);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static unsafe extern bool SetConsoleWindowInfo(IntPtr hConsoleOutput,
            bool absolute, SMALL_RECT* consoleWindow);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool SetConsoleTextAttribute(IntPtr hConsoleOutput, short attributes);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool SetConsoleCursorPosition(IntPtr hConsoleOutput,
            COORD cursorPosition);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetConsoleCursorInfo(IntPtr hConsoleOutput,
            out CONSOLE_CURSOR_INFO cci);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool SetConsoleCursorInfo(IntPtr hConsoleOutput,
            ref CONSOLE_CURSOR_INFO cci);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int GetConsoleTitle(StringBuilder sb, int capacity);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool SetConsoleTitle(String title);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool ReadConsoleInput(IntPtr hConsoleInput, out InputRecord buffer, int numInputRecords_UseOne, out int numEventsRead);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool PeekConsoleInput(IntPtr hConsoleInput, out InputRecord buffer, int numInputRecords_UseOne, out int numEventsRead);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static unsafe extern bool ReadConsoleOutput(IntPtr hConsoleOutput, CHAR_INFO* pBuffer, COORD bufferSize, COORD bufferCoord, ref SMALL_RECT readRegion);

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static unsafe extern bool WriteConsoleOutput(IntPtr hConsoleOutput, CHAR_INFO* buffer, COORD bufferSize, COORD bufferCoord, ref SMALL_RECT writeRegion);

        [DllImport(USER32)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern short GetKeyState(int virtualKeyCode);
#endif

        [DllImport(KERNEL32, SetLastError = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern uint GetConsoleCP();

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool SetConsoleCP(uint codePage);

        [DllImport(KERNEL32, SetLastError = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern uint GetConsoleOutputCP();

        [DllImport(KERNEL32, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern bool SetConsoleOutputCP(uint codePage);

#if !FEATURE_PAL
        public const int VER_PLATFORM_WIN32s = 0;
        public const int VER_PLATFORM_WIN32_WINDOWS = 1;
        public const int VER_PLATFORM_WIN32_NT = 2;
        public const int VER_PLATFORM_WINCE = 3;

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int RegConnectRegistry(String machineName,
                    SafeRegistryHandle key, out SafeRegistryHandle result);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int RegCreateKeyEx(SafeRegistryHandle hKey, String lpSubKey,
                    int Reserved, String lpClass, int dwOptions,
                    int samDesigner, SECURITY_ATTRIBUTES lpSecurityAttributes,
                    out SafeRegistryHandle hkResult, out int lpdwDisposition);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int RegDeleteKey(SafeRegistryHandle hKey, String lpSubKey);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int RegDeleteValue(SafeRegistryHandle hKey, String lpValueName);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegEnumKeyEx(SafeRegistryHandle hKey, int dwIndex,
                    StringBuilder lpName, out int lpcbName, int[] lpReserved,
                    StringBuilder lpClass, int[] lpcbClass,
                    long[] lpftLastWriteTime);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegEnumValue(SafeRegistryHandle hKey, int dwIndex,
                    StringBuilder lpValueName, ref int lpcbValueName,
                    IntPtr lpReserved_MustBeZero, int[] lpType, byte[] lpData,
                    int[] lpcbData);

        [DllImport(ADVAPI32, CharSet = CharSet.Ansi, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegEnumValueA(SafeRegistryHandle hKey, int dwIndex,
                     StringBuilder lpValueName, ref int lpcbValueName,
                     IntPtr lpReserved_MustBeZero, int[] lpType, byte[] lpData,
                     int[] lpcbData);


        [DllImport(ADVAPI32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegFlushKey(SafeRegistryHandle hKey);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int RegOpenKeyEx(SafeRegistryHandle hKey, String lpSubKey,
                    int ulOptions, int samDesired, out SafeRegistryHandle hkResult);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegQueryInfoKey(SafeRegistryHandle hKey, StringBuilder lpClass,
                    int[] lpcbClass, IntPtr lpReserved_MustBeZero, ref int lpcSubKeys,
                    int[] lpcbMaxSubKeyLen, int[] lpcbMaxClassLen,
                    ref int lpcValues, int[] lpcbMaxValueNameLen,
                    int[] lpcbMaxValueLen, int[] lpcbSecurityDescriptor,
                    int[] lpftLastWriteTime);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int[] lpReserved, ref int lpType, [Out] byte[] lpData,
                    ref int lpcbData);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int[] lpReserved, ref int lpType, ref int lpData,
                    ref int lpcbData);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int[] lpReserved, ref int lpType, ref long lpData,
                    ref int lpcbData);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                     int[] lpReserved, ref int lpType, [Out] char[] lpData,
                     ref int lpcbData);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int[] lpReserved, ref int lpType, StringBuilder lpData,
                    ref int lpcbData);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegSetValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int Reserved, RegistryValueKind dwType, byte[] lpData, int cbData);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegSetValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int Reserved, RegistryValueKind dwType, ref int lpData, int cbData);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegSetValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int Reserved, RegistryValueKind dwType, ref long lpData, int cbData);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int RegSetValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int Reserved, RegistryValueKind dwType, String lpData, int cbData);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern int ExpandEnvironmentStrings(String lpSrc, StringBuilder lpDst, int nSize);

        [DllImport(KERNEL32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr LocalReAlloc(IntPtr handle, IntPtr sizetcbBytes, int uFlags);

        public const int SHGFP_TYPE_CURRENT = 0;
        public const int UOI_FLAGS = 1;
        public const int WSF_VISIBLE = 1;
        public const int CSIDL_APPDATA = 0x001a;
        public const int CSIDL_COMMON_APPDATA = 0x0023;
        public const int CSIDL_LOCAL_APPDATA = 0x001c;
        public const int CSIDL_COOKIES = 0x0021;
        public const int CSIDL_FAVORITES = 0x0006;
        public const int CSIDL_HISTORY = 0x0022;
        public const int CSIDL_INTERNET_CACHE = 0x0020;
        public const int CSIDL_PROGRAMS = 0x0002;
        public const int CSIDL_RECENT = 0x0008;
        public const int CSIDL_SENDTO = 0x0009;
        public const int CSIDL_STARTMENU = 0x000b;
        public const int CSIDL_STARTUP = 0x0007;
        public const int CSIDL_SYSTEM = 0x0025;
        public const int CSIDL_TEMPLATES = 0x0015;
        public const int CSIDL_DESKTOPDIRECTORY = 0x0010;
        public const int CSIDL_PERSONAL = 0x0005;
        public const int CSIDL_PROGRAM_FILES = 0x0026;
        public const int CSIDL_PROGRAM_FILES_COMMON = 0x002b;
        public const int CSIDL_DESKTOP = 0x0000;
        public const int CSIDL_DRIVES = 0x0011;
        public const int CSIDL_MYMUSIC = 0x000d;
        public const int CSIDL_MYPICTURES = 0x0027;

        [DllImport(SHFOLDER, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);

        public const int NameSamCompatible = 2;

        [ResourceExposure(ResourceScope.None)]
        [DllImport(SECUR32, CharSet = CharSet.Unicode, SetLastError = true)]

        public static extern byte GetUserNameEx(int format, StringBuilder domainName, ref int domainNameLen);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool LookupAccountName(string machineName, string accountName, byte[] sid,
                                 ref int sidLen, StringBuilder domainName, ref int domainNameLen, out int peUse);

        [DllImport(USER32, ExactSpelling = true)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern IntPtr GetProcessWindowStation();

        [DllImport(USER32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool GetUserObjectInformation(IntPtr hObj, int nIndex,
            [MarshalAs(UnmanagedType.LPStruct)] USEROBJECTFLAGS pvBuffer, int nLength, ref int lpnLengthNeeded);

        [DllImport(USER32, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern IntPtr SendMessageTimeout(IntPtr hWnd, int Msg, IntPtr wParam, String lParam, uint fuFlags, uint uTimeout, IntPtr lpdwResult);

        [StructLayout(LayoutKind.Sequential)]
        public class USEROBJECTFLAGS
        {
            public int fInherit = 0;
            public int fReserved = 0;
            public int dwFlags = 0;
        }

        [DllImport(ADVAPI32, CharSet = CharSet.Unicode, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        int LsaNtStatusToWinError(
            [In]    int status);

#if !FEATURE_PAL
        [DllImport("bcrypt.dll")]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern uint BCryptGetFipsAlgorithmMode(
                [MarshalAs(UnmanagedType.U1), Out]out bool pfEnabled);
#endif

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [DllImport(ADVAPI32, CharSet = CharSet.Unicode, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        bool AdjustTokenPrivileges(
            [In]     SafeTokenHandle TokenHandle,
            [In]     bool DisableAllPrivileges,
            [In]     ref TOKEN_PRIVILEGE NewState,
            [In]     uint BufferLength,
            [In, Out] ref TOKEN_PRIVILEGE PreviousState,
            [In, Out] ref uint ReturnLength);

        [DllImport(ADVAPI32, CharSet = CharSet.Unicode, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        bool AllocateLocallyUniqueId(
            [In, Out] ref LUID Luid);

        [DllImport(ADVAPI32, CharSet = CharSet.Unicode, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        bool CheckTokenMembership(
            [In]     SafeTokenHandle TokenHandle,
            [In]     byte[] SidToCheck,
            [In, Out] ref bool IsMember);

        [DllImport(
             ADVAPI32,
             EntryPoint = "ConvertSecurityDescriptorToStringSecurityDescriptorW",
             CallingConvention = CallingConvention.Winapi,
             SetLastError = true,
             CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern BOOL ConvertSdToStringSd(
            byte[] securityDescriptor,
            DWORD requestedRevision,
            ULONG securityInformation,
            out IntPtr resultString,
            ref ULONG resultStringLength);

        [DllImport(
             ADVAPI32,
             EntryPoint = "ConvertStringSecurityDescriptorToSecurityDescriptorW",
             CallingConvention = CallingConvention.Winapi,
             SetLastError = true,
             CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern BOOL ConvertStringSdToSd(
            string stringSd,
            DWORD stringSdRevision,
            out IntPtr resultSd,
            ref ULONG resultSdLength);

        [DllImport(
             ADVAPI32,
             EntryPoint = "ConvertStringSidToSidW",
             CallingConvention = CallingConvention.Winapi,
             SetLastError = true,
             CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern BOOL ConvertStringSidToSid(
            string stringSid,
            out IntPtr ByteArray
            );

        [DllImport(
             ADVAPI32,
             EntryPoint = "CreateWellKnownSid",
             CallingConvention = CallingConvention.Winapi,
             SetLastError = true,
             CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern BOOL CreateWellKnownSid(
            int sidType,
            byte[] domainSid,
            [Out] byte[] resultSid,
            ref DWORD resultSidLength);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern
        bool DuplicateHandle(
            [In]     IntPtr hSourceProcessHandle,
            [In]     IntPtr hSourceHandle,
            [In]     IntPtr hTargetProcessHandle,
            [In, Out] ref SafeTokenHandle lpTargetHandle,
            [In]     uint dwDesiredAccess,
            [In]     bool bInheritHandle,
            [In]     uint dwOptions);

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern
        bool DuplicateHandle(
            [In]     IntPtr hSourceProcessHandle,
            [In]     SafeTokenHandle hSourceHandle,
            [In]     IntPtr hTargetProcessHandle,
            [In, Out] ref SafeTokenHandle lpTargetHandle,
            [In]     uint dwDesiredAccess,
            [In]     bool bInheritHandle,
            [In]     uint dwOptions);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        bool DuplicateTokenEx(
            [In]     SafeTokenHandle hExistingToken,
            [In]     uint dwDesiredAccess,
            [In]     IntPtr lpTokenAttributes,
            [In]     uint ImpersonationLevel,
            [In]     uint TokenType,
            [In, Out] ref SafeTokenHandle phNewToken);

        [DllImport(
             ADVAPI32,
             EntryPoint = "EqualDomainSid",
             CallingConvention = CallingConvention.Winapi,
             SetLastError = true,
             CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern BOOL IsEqualDomainSid(
            byte[] sid1,
            byte[] sid2,
            out bool result);

        [DllImport(KERNEL32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern IntPtr GetCurrentProcess();

        [DllImport(
             ADVAPI32,
             EntryPoint = "GetSecurityDescriptorLength",
             CallingConvention = CallingConvention.Winapi,
             SetLastError = true,
             CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern DWORD GetSecurityDescriptorLength(
            IntPtr byteArray);

        [DllImport(
             ADVAPI32,
             EntryPoint = "GetSecurityInfo",
             CallingConvention = CallingConvention.Winapi,
             SetLastError = true,
             CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern DWORD GetSecurityInfoByHandle(
            SafeHandle handle,
            DWORD objectType,
            DWORD securityInformation,
            out IntPtr sidOwner,
            out IntPtr sidGroup,
            out IntPtr dacl,
            out IntPtr sacl,
            out IntPtr securityDescriptor);

        [DllImport(
             ADVAPI32,
             EntryPoint = "GetNamedSecurityInfoW",
             CallingConvention = CallingConvention.Winapi,
             SetLastError = true,
             CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern DWORD GetSecurityInfoByName(
            string name,
            DWORD objectType,
            DWORD securityInformation,
            out IntPtr sidOwner,
            out IntPtr sidGroup,
            out IntPtr dacl,
            out IntPtr sacl,
            out IntPtr securityDescriptor);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        bool GetTokenInformation(
            [In]  IntPtr TokenHandle,
            [In]  uint TokenInformationClass,
            [In]  SafeLocalAllocHandle TokenInformation,
            [In]  uint TokenInformationLength,
            [Out] out uint ReturnLength);

        [DllImport(ADVAPI32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        bool GetTokenInformation(
            [In]  SafeTokenHandle TokenHandle,
            [In]  uint TokenInformationClass,
            [In]  SafeLocalAllocHandle TokenInformation,
            [In]  uint TokenInformationLength,
            [Out] out uint ReturnLength);

        [DllImport(
             ADVAPI32,
             EntryPoint = "GetWindowsAccountDomainSid",
             CallingConvention = CallingConvention.Winapi,
             SetLastError = true,
             CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern BOOL GetWindowsAccountDomainSid(
            byte[] sid,
            [Out] byte[] resultSid,
            ref DWORD resultSidLength);

        public enum SECURITY_IMPERSONATION_LEVEL
        {
            Anonymous = 0,
            Identification = 1,
            Impersonation = 2,
            Delegation = 3,
        }

        [DllImport(
             ADVAPI32,
             EntryPoint = "IsWellKnownSid",
             CallingConvention = CallingConvention.Winapi,
             SetLastError = true,
             CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern BOOL IsWellKnownSid(
            byte[] sid,
            int type);

        [DllImport(
            ADVAPI32,
            EntryPoint = "LsaOpenPolicy",
            CallingConvention = CallingConvention.Winapi,
            SetLastError = true,
            CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern DWORD LsaOpenPolicy(
            string systemName,
            ref LSA_OBJECT_ATTRIBUTES attributes,
            int accessMask,
            out SafeLsaPolicyHandle handle
            );

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [DllImport(
            ADVAPI32,
            EntryPoint = "LookupPrivilegeValueW",
            CharSet = CharSet.Auto,
            SetLastError = true,
            BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        bool LookupPrivilegeValue(
            [In]     string lpSystemName,
            [In]     string lpName,
            [In, Out] ref LUID Luid);

        [DllImport(
            ADVAPI32,
            EntryPoint = "LsaLookupSids",
            CallingConvention = CallingConvention.Winapi,
            SetLastError = true,
            CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern DWORD LsaLookupSids(
            SafeLsaPolicyHandle handle,
            int count,
            IntPtr[] sids,
            ref SafeLsaMemoryHandle referencedDomains,
            ref SafeLsaMemoryHandle names
            );

        [DllImport(ADVAPI32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern int LsaFreeMemory(IntPtr handle);

        [DllImport(
            ADVAPI32,
            EntryPoint = "LsaLookupNames",
            CallingConvention = CallingConvention.Winapi,
            SetLastError = true,
            CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern DWORD LsaLookupNames(
            SafeLsaPolicyHandle handle,
            int count,
            UNICODE_STRING[] names,
            ref SafeLsaMemoryHandle referencedDomains,
            ref SafeLsaMemoryHandle sids
            );

        [DllImport(
            ADVAPI32,
            EntryPoint = "LsaLookupNames2",
            CallingConvention = CallingConvention.Winapi,
            SetLastError = true,
            CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern DWORD LsaLookupNames2(
            SafeLsaPolicyHandle handle,
            int flags,
            int count,
            UNICODE_STRING[] names,
            ref SafeLsaMemoryHandle referencedDomains,
            ref SafeLsaMemoryHandle sids
            );

        [DllImport(SECUR32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        int LsaConnectUntrusted(
            [In, Out] ref SafeLsaLogonProcessHandle LsaHandle);

        [DllImport(SECUR32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        int LsaGetLogonSessionData(
            [In]     ref LUID LogonId,
            [In, Out] ref SafeLsaReturnBufferHandle ppLogonSessionData);

        [DllImport(SECUR32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        int LsaLogonUser(
            [In]     SafeLsaLogonProcessHandle LsaHandle,
            [In]     ref UNICODE_INTPTR_STRING OriginName,
            [In]     uint LogonType,
            [In]     uint AuthenticationPackage,
            [In]     IntPtr AuthenticationInformation,
            [In]     uint AuthenticationInformationLength,
            [In]     IntPtr LocalGroups,
            [In]     ref TOKEN_SOURCE SourceContext,
            [In, Out] ref SafeLsaReturnBufferHandle ProfileBuffer,
            [In, Out] ref uint ProfileBufferLength,
            [In, Out] ref LUID LogonId,
            [In, Out] ref SafeTokenHandle Token,
            [In, Out] ref QUOTA_LIMITS Quotas,
            [In, Out] ref int SubStatus);

        [DllImport(SECUR32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        int LsaLookupAuthenticationPackage(
            [In]     SafeLsaLogonProcessHandle LsaHandle,
            [In]     ref UNICODE_INTPTR_STRING PackageName,
            [In, Out] ref uint AuthenticationPackage);

        [DllImport(SECUR32, CharSet = CharSet.Auto, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        public static extern
        int LsaRegisterLogonProcess(
            [In]     ref UNICODE_INTPTR_STRING LogonProcessName,
            [In, Out] ref SafeLsaLogonProcessHandle LsaHandle,
            [In, Out] ref IntPtr SecurityMode);

        [DllImport(SECUR32, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern int LsaDeregisterLogonProcess(IntPtr handle);

        [DllImport(ADVAPI32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern int LsaClose(IntPtr handle);

        [DllImport(SECUR32, SetLastError = true)]
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static extern int LsaFreeReturnBuffer(IntPtr handle);

        [DllImport(ADVAPI32, CharSet = CharSet.Unicode, SetLastError = true)]
        [ResourceExposure(ResourceScope.Process)]
        public static extern
        bool OpenProcessToken(
            [In]     IntPtr ProcessToken,
            [In]     TokenAccessLevels DesiredAccess,
            [In, Out] ref SafeTokenHandle TokenHandle);

        [DllImport(
             ADVAPI32,
             EntryPoint = "SetNamedSecurityInfoW",
             CallingConvention = CallingConvention.Winapi,
             SetLastError = true,
             CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.Machine)]
        public static extern DWORD SetSecurityInfoByName(
            string name,
            DWORD objectType,
            DWORD securityInformation,
            byte[] owner,
            byte[] group,
            byte[] dacl,
            byte[] sacl);

        [DllImport(
             ADVAPI32,
             EntryPoint = "SetSecurityInfo",
             CallingConvention = CallingConvention.Winapi,
             SetLastError = true,
             CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        public static extern DWORD SetSecurityInfoByHandle(
            SafeHandle handle,
            DWORD objectType,
            DWORD securityInformation,
            byte[] owner,
            byte[] group,
            byte[] dacl,
            byte[] sacl);

#else 

        // managed cryptography wrapper around the PALRT cryptography api 
        public const int PAL_HCRYPTPROV = 123;

        public const int CALG_MD2         = ((4 << 13) | 1);
        public const int CALG_MD4         = ((4 << 13) | 2); 
        public const int CALG_MD5         = ((4 << 13) | 3);
        public const int CALG_SHA         = ((4 << 13) | 4); 
        public const int CALG_SHA1        = ((4 << 13) | 4); 
        public const int CALG_MAC         = ((4 << 13) | 5);
        public const int CALG_SSL3_SHAMD5 = ((4 << 13) | 8); 
        public const int CALG_HMAC        = ((4 << 13) | 9);

        public const int HP_ALGID         = 0x0001;
        public const int HP_HASHVAL       = 0x0002; 
        public const int HP_HASHSIZE      = 0x0004;
 
        [DllImport(OLEAUT32, CharSet=CharSet.Unicode, EntryPoint="CryptAcquireContextW")] 
        [ResourceExposure(ResourceScope.Machine)]
        public extern static bool CryptAcquireContext(out IntPtr hProv, 
                           [MarshalAs(UnmanagedType.LPWStr)] string container,
                           [MarshalAs(UnmanagedType.LPWStr)] string provider,
                           int provType,
                           int flags); 

        [DllImport(OLEAUT32, SetLastError=true)] 
        [ResourceExposure(ResourceScope.None)] 
        public extern static bool CryptReleaseContext( IntPtr hProv, int flags);
 
        [DllImport(OLEAUT32, SetLastError=true)]
        [ResourceExposure(ResourceScope.None)]
        public extern static bool CryptCreateHash(IntPtr hProv, int Algid, IntPtr hKey, int flags, out IntPtr hHash);
 
        [DllImport(OLEAUT32, SetLastError=true)]
        [ResourceExposure(ResourceScope.None)] 
        public extern static bool CryptDestroyHash(IntPtr hHash); 

        [DllImport(OLEAUT32, SetLastError=true)] 
        [ResourceExposure(ResourceScope.None)]
        public extern static bool CryptHashData(IntPtr hHash,
                           [In, MarshalAs(UnmanagedType.LPArray)] byte[] data,
                           int length, 
                           int flags);
 
        [DllImport(OLEAUT32, SetLastError=true)] 
        [ResourceExposure(ResourceScope.None)]
        public extern static bool CryptGetHashParam(IntPtr hHash, 
                           int param,
                           [Out, MarshalAs(UnmanagedType.LPArray)] byte[] digest,
                           ref int length,
                           int flags); 

        [DllImport(OLEAUT32, SetLastError=true)] 
        [ResourceExposure(ResourceScope.None)] 
        public extern static bool CryptGetHashParam(IntPtr hHash,
                           int param, 
                           out int data,
                           ref int length,
                           int flags);
 
        [DllImport(KERNEL32, EntryPoint="PAL_Random")]
        [ResourceExposure(ResourceScope.None)] 
        public extern static bool Random(bool bStrong, 
                           [Out, MarshalAs(UnmanagedType.LPArray)] byte[] buffer, int length);
#endif
#if FEATURE_COMINTEROP
 
        [DllImport(MSCORWKS, CharSet=CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)] 
        public static extern int CreateAssemblyNameObject(out IAssemblyName ppEnum, String szAssemblyName, uint dwFlags, IntPtr pvReserved); 

        [DllImport(MSCORWKS, CharSet=CharSet.Auto)] 
        [ResourceExposure(ResourceScope.None)]
        public static extern int CreateAssemblyEnum(out IAssemblyEnum ppEnum, IApplicationContext pAppCtx, IAssemblyName pName, uint dwFlags, IntPtr pvReserved);
#endif
        [DllImport(KERNEL32, CharSet = CharSet.Auto, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        public extern static int GetCalendarInfo(
                                      int Locale,
                                      int Calendar,
                                      int CalType,
                                      StringBuilder lpCalData,
                                      int cchData,
                                      IntPtr lpValue
                                    );
    }
}
