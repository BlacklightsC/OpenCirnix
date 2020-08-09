using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cirnix.JassNative.Runtime.Blizzard.Storm;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 52)]
    public struct Hashtable
    {
        public unsafe void* list_destroy_method;
        public int NodeOffset;
        public int field0008;
        public unsafe HT_Node* NodeList;
        public int field0010;
        public int field0014;
        public int BucketCount;
        public unsafe HT_Bucket* Buckets;
        public int field0020;
        public int Bitmask;
        public HT_Bucket BucketArray;

        public unsafe HT_Node* Lookup(string key)
        {
            if (string.IsNullOrEmpty(key) || Bitmask == -1)
                return null;
            int num = SStr.HashHT(key);
            for (HT_Node* htNodePtr = Buckets[Bitmask & num].List; (int)htNodePtr > 0; htNodePtr = htNodePtr->Next)
            {
                if (num == htNodePtr->Hash && key == htNodePtr->Key.AsString())
                    return htNodePtr;
            }
            return null;
        }

        public unsafe void* LookupValue(string key)
        {
            HT_Node* htNodePtr = Lookup(key);
            if ((IntPtr)htNodePtr == IntPtr.Zero)
                return null;
            return htNodePtr->Value;
        }

        public unsafe bool ContainsKey(string key)
        {
            if (string.IsNullOrEmpty(key) || Bitmask == -1)
                return false;
            int num = SStr.HashHT(key);
            for (HT_Node* htNodePtr = Buckets[Bitmask & num].List; (int)htNodePtr > 0; htNodePtr = htNodePtr->Next)
            {
                if (num == htNodePtr->Hash && key == htNodePtr->Key.AsString())
                    return true;
            }
            return false;
        }

        public unsafe HT_Node*[] GetAllValues()
        {
            List<IntPtr> numList = new List<IntPtr>();
            int bucketCount = BucketCount;
            for (int index = 0; index < bucketCount; ++index)
            {
                for (HT_Node* htNodePtr = Buckets[index].List; (int)htNodePtr > 0; htNodePtr = htNodePtr->Next)
                    numList.Add((IntPtr)(void*)htNodePtr);
            }
            HT_Node*[] htNodePtrArray = new HT_Node*[numList.Count];
            for (int index = 0; index < htNodePtrArray.Length; ++index)
                htNodePtrArray[index] = (HT_Node*)(void*)numList[index];
            return htNodePtrArray;
        }
    }
}