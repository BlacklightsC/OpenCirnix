using System;
using System.Runtime.InteropServices;
using Cirnix.JassNative.Runtime.Utilities.UnmanagedCalls;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct CUnit : IAgent<CUnitInternal>
    {
        private readonly IntPtr pointer;

        public static unsafe CUnit FromPointer(CUnitInternal* pointer)
        {
            return new CUnit(new IntPtr((void*)pointer));
        }

        public static unsafe CUnit FromPointer(void* pointer)
        {
            return new CUnit(new IntPtr(pointer));
        }

        public static CUnit FromPointer(IntPtr pointer)
        {
            return new CUnit(pointer);
        }

        public static CUnit FromHandle(IntPtr handle)
        {
            return FastCall.Invoke<CUnit>(GameAddresses.GetUnitFromHandle, handle);
        }

        private CUnit(IntPtr pointer)
        {
            this.pointer = pointer;
        }

        public IntPtr AsIntPtr()
        {
            return pointer;
        }

        public unsafe CUnitInternal* AsUnsafe()
        {
            return (CUnitInternal*)(void*)pointer;
        }

        public CAgent ToBase()
        {
            return CAgent.FromPointer(pointer);
        }

        public unsafe CAbilityPtr GetAbility(ObjectIdL ability)
        {
            return AsUnsafe()->GetAbility(ability)->AsSafe();
        }

        public CAbilityPtr GetAttackAbility()
        {
            return GetAbility(new ObjectIdL("Aatk"));
        }

        public CAbilityPtr GetMovementAbility()
        {
            return GetAbility(new ObjectIdL("Amov"));
        }

        public CAbilityPtr GetHeroAbility()
        {
            return GetAbility(new ObjectIdL("AHer"));
        }

        public CAbilityPtr GetBuildAbility()
        {
            return GetAbility(new ObjectIdL("ANbu"));
        }

        public CAbilityPtr GetInventoryAbility()
        {
            return GetAbility(new ObjectIdL("AInv"));
        }
    }
}