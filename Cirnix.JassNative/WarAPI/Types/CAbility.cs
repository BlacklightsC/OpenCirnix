using System;
using System.Collections.Generic;
using Cirnix.JassNative.Runtime.Blizzard.Storm;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct CAbility : IAgentInternal<CAbilityPtr>
    {
        private static Dictionary<IntPtr, bool> isCAbilityDataUnique = new Dictionary<IntPtr, bool>();
        public unsafe VTable* Virtual;
        public IntPtr field0004;
        public IntPtr field0008;
        public IntPtr field000C;
        public IntPtr field0010;
        public IntPtr field0014;
        public IntPtr field0018;
        public IntPtr field001C;
        public IntPtr field0020;
        public IntPtr field0024;
        public IntPtr field0028;
        public IntPtr field002C;
        public unsafe CUnitInternal* Owner;
        public ObjectIdL AbilityId;
        public IntPtr field0038;
        public IntPtr field003C;
        public IntPtr field0040;
        public IntPtr field0044;
        public IntPtr field0048;
        public IntPtr field004C;
        public IntPtr field0050;
        public unsafe AbilDataCacheNode* Data;
        public IntPtr field0058;
        public IntPtr field005C;

        public unsafe CAbilityPtr AsSafe()
        {
            fixed (CAbility* pointer = &this)
                return new CAbilityPtr(pointer);
        }

        public unsafe IntPtr AsIntPtr()
        {
            fixed (CAbility* cabilityPtr = &this)
                return new IntPtr((void*)cabilityPtr);
        }

        public unsafe CAgentInternal* ToBase()
        {
            fixed (CAbility* cabilityPtr = &this)
                return (CAgentInternal*)cabilityPtr;
        }

        public unsafe ObjectIdL GetClassId()
        {
            return ToBase()->GetClassId();
        }

        public unsafe string GetClassName()
        {
            return ToBase()->GetClassName();
        }

        public unsafe bool MakeDataUnique()
        {
            isCAbilityDataUnique.TryGetValue(AsIntPtr(), out bool flag);
            if (flag) return false;
            Data = AbilDataCacheNode.FromId(AbilityId)->Clone();
            isCAbilityDataUnique[AsIntPtr()] = true;
            return true;
        }

        public unsafe bool MakeDataShared()
        {
            isCAbilityDataUnique.TryGetValue(AsIntPtr(), out bool flag);
            if (!flag) return false;
            SMem.Free((void*)Data, 0);
            Data = AbilDataCacheNode.FromId(AbilityId);
            isCAbilityDataUnique[AsIntPtr()] = false;
            return true;
        }

        public struct VTable
        {
            public unsafe IntPtr* Function;
        }
    }
}
