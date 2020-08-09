using System;
using Cirnix.JassNative.Runtime.Blizzard.Storm;
using Cirnix.JassNative.Runtime.Utilities;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct AbilDataCacheNode
    {
        public IntPtr field0000;
        public IntPtr field0004;
        public IntPtr field0008;
        public IntPtr field000C;
        public IntPtr field0010;
        public ObjectIdL AbilityId_0;
        public ObjectIdL AbilityId_1;
        public IntPtr field001C;
        public IntPtr field0020;
        public IntPtr field0024;
        public IntPtr field0028;
        public IntPtr field002C;
        public ObjectIdL BaseAbilityId;
        public ObjectIdL AbilityId;
        public IntPtr field0038;
        public IntPtr field003C;
        public IntPtr field0040;
        public IntPtr field0044;
        public IntPtr field0048;
        public IntPtr field004C;
        public int Levels;
        public unsafe AbilityLevelData* Level;

        public static unsafe AbilDataCacheNode* FromId(ObjectIdL id)
        {
            return GameFunctions.GetAbilDataCacheNodeFromId(id).AsUnsafe();
        }

        public unsafe AbilDataCacheNodePtr AsSafe()
        {
            fixed (AbilDataCacheNode* pointer = &this)
                return new AbilDataCacheNodePtr(pointer);
        }

        public unsafe IntPtr AsIntPtr()
        {
            fixed (AbilDataCacheNode* abilDataCacheNodePtr = &this)
                return new IntPtr((void*)abilDataCacheNodePtr);
        }

        public unsafe AbilDataCacheNode* Clone()
        {
            fixed (AbilDataCacheNode* abilDataCacheNodePtr1 = &this)
            {
                AbilDataCacheNode* abilDataCacheNodePtr2 = (AbilDataCacheNode*)SMem.Alloc(sizeof(AbilDataCacheNode), 0);
                Memory.Copy(new IntPtr((void*)abilDataCacheNodePtr1), new IntPtr((void*)abilDataCacheNodePtr2), sizeof(AbilDataCacheNode));
                AbilityLevelData* abilityLevelDataPtr = (AbilityLevelData*)SMem.Alloc(sizeof(AbilityLevelData) * Levels, 0);
                Memory.Copy(new IntPtr((void*)Level), new IntPtr((void*)abilityLevelDataPtr), sizeof(AbilityLevelData) * Levels);
                abilDataCacheNodePtr2->Level = abilityLevelDataPtr;
                return abilDataCacheNodePtr2;
            }
        }
    }
}
