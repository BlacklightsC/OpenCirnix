using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cirnix.JassNative.Runtime.Windows
{
    public struct PROCESS_INFORMATION
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public UInt32 dwProcessId;
        public UInt32 dwThreadId;
    }
}
