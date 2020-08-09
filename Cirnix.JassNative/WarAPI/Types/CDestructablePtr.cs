using System;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct CDestructablePtr
    {
        private IntPtr pointer;

        public static CDestructablePtr FromHandle(IntPtr destructableJassHandle)
        {
            return GameFunctions.GetDestructableFromHandle(destructableJassHandle);
        }

        public unsafe CDestructablePtr(CDestructable* pointer)
        {
            this.pointer = new IntPtr((void*)pointer);
        }

        public CDestructablePtr(IntPtr pointer)
        {
            this.pointer = pointer;
        }

        public unsafe CDestructable* AsUnsafe() => (CDestructable*)(void*)pointer;

        public IntPtr AsIntPtr() => pointer;
    }
}