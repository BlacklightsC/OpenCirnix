using System;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct CItemPtr
    {
        private IntPtr pointer;

        public static CItemPtr FromHandle(IntPtr itemJassHandle)
        {
            return GameFunctions.GetItemFromHandle(itemJassHandle);
        }

        public unsafe CItemPtr(CItem* pointer)
        {
            this.pointer = new IntPtr((void*)pointer);
        }

        public unsafe CItem* AsUnsafe()
        {
            return (CItem*)(void*)this.pointer;
        }

        public IntPtr AsIntPtr()
        {
            return this.pointer;
        }
    }
}