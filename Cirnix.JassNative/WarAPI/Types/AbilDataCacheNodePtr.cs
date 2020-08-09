using System;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct AbilDataCacheNodePtr
    {
        private IntPtr pointer;

        public static AbilDataCacheNodePtr FromId(ObjectIdL id)
        {
            return GameFunctions.GetAbilDataCacheNodeFromId(id);
        }

        public unsafe AbilDataCacheNodePtr(AbilDataCacheNode* pointer)
        {
            this.pointer = new IntPtr((void*)pointer);
        }

        public unsafe AbilDataCacheNode* AsUnsafe() => (AbilDataCacheNode*)(void*)pointer;

        public IntPtr AsIntPtr() => pointer;
    }
}