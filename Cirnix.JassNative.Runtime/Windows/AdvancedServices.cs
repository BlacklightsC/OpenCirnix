using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.Runtime.Windows
{
    public static class AdvancedServices
    {
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int OpenProcessToken(IntPtr ProcessHandle, int DesiredAccess, ref int tokenhandle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetCurrentProcess();

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int LookupPrivilegeValue(string lpsystemname, string lpname, ref long lpLuid);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int AdjustTokenPrivileges(int tokenhandle, int disableprivs, ref TOKEN_PRIVILEGES Newstate, int bufferlength, int PreivousState, int Returnlength);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetSecurityInfo(IntPtr HANDLE, int SE_OBJECT_TYPE, int SECURITY_INFORMATION, int psidOwner, int psidGroup, out IntPtr pDACL, IntPtr pSACL, out IntPtr pSecurityDescriptor);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetSecurityInfo(IntPtr HANDLE, int SE_OBJECT_TYPE, int SECURITY_INFORMATION, int psidOwner, int psidGroup, IntPtr pDACL, IntPtr pSACL);
    }
}
