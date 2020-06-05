using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct CAgent : IAgent<CAgentInternal>
    {
        private readonly IntPtr pointer;

        public static unsafe CAgent FromPointer(CAgentInternal* pointer)
        {
            return new CAgent(new IntPtr((void*)pointer));
        }

        public static unsafe CAgent FromPointer(void* pointer)
        {
            return new CAgent(new IntPtr(pointer));
        }

        public static CAgent FromPointer(IntPtr pointer)
        {
            return new CAgent(pointer);
        }

        private CAgent(IntPtr pointer)
        {
            this.pointer = pointer;
        }

        public IntPtr AsIntPtr()
        {
            return pointer;
        }

        public unsafe CAgentInternal* AsUnsafe()
        {
            return (CAgentInternal*)(void*)pointer;
        }

        public CAgent ToBase()
        {
            return this;
        }
    }
}
