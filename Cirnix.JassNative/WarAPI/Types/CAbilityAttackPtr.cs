using System;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct CAbilityAttackPtr
    {
        private IntPtr pointer;

        public unsafe CAbilityAttackPtr(CAbilityAttack* pointer)
        {
            this.pointer = new IntPtr((void*)pointer);
        }

        public unsafe CAbilityAttack* AsUnsafe()
        {
            return (CAbilityAttack*)(void*)this.pointer;
        }

        public IntPtr AsIntPtr()
        {
            return this.pointer;
        }
    }
}
