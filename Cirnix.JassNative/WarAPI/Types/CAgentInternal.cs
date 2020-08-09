using System;

using Cirnix.JassNative.Runtime.Utilities;
using Cirnix.JassNative.Runtime.Utilities.UnmanagedCalls;

namespace Cirnix.JassNative.WarAPI.Types
{
    public struct CAgentInternal : IAgentInternal<CAgent>
    {
        public unsafe VTable* Virtual;

        public unsafe IntPtr AsIntPtr()
        {
            fixed (CAgentInternal* cagentInternalPtr = &this)
                return new IntPtr((void*)cagentInternalPtr);
        }

        public unsafe CAgent AsSafe()
        {
            fixed (CAgentInternal* pointer = &this)
                return CAgent.FromPointer(pointer);
        }

        public unsafe CAgentInternal* ToBase()
        {
            fixed (CAgentInternal* cagentInternalPtr = &this)
                return cagentInternalPtr;
        }

        public unsafe ObjectIdL GetClassId()
        {
            return ThisCall.Invoke<ObjectIdL>(Virtual->CAgent__GetClassId, AsSafe());
        }

        public ObjectIdL ClassId => GetClassId();

        public unsafe string GetClassName()
        {
            return Memory.ReadString(ThisCall.Invoke<IntPtr>(Virtual->CAgent__GetClassName, AsSafe()));
        }

        public string ClassName => GetClassName();

        public struct VTable
        {
            public IntPtr Func01;
            public IntPtr Func02;
            public IntPtr Func03;
            public IntPtr Func04;
            public IntPtr Func05;
            public IntPtr Func06;
            public IntPtr Func07;
            public IntPtr CAgent__GetClassId;
            public IntPtr Func09;
            public IntPtr Func10;
            public IntPtr Func11;
            public IntPtr Func12;
            public IntPtr Func13;
            public IntPtr Func14;
            public IntPtr Func15;
            public IntPtr Func16;
            public IntPtr Func17;
            public IntPtr Func18;
            public IntPtr Func19;
            public IntPtr Func20;
            public IntPtr Func21;
            public IntPtr Func22;
            public IntPtr CAgent__GetClassName;
        }
    }
}
