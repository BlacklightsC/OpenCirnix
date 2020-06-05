using System;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct CAbilityPtr
    {
        private IntPtr pointer;

        public unsafe CAbilityPtr(CAbility* pointer)
        {
            this.pointer = new IntPtr((void*)pointer);
        }

        public unsafe CAbility* AsUnsafe()
        {
            return (CAbility*)(void*)pointer;
        }

        public IntPtr AsIntPtr()
        {
            return pointer;
        }
    }
}