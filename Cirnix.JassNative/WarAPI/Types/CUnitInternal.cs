using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Cirnix.JassNative.Runtime.Utilities.UnmanagedCalls;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Sequential, Size = 784)]
    public struct CUnitInternal : IAgentInternal<CUnit>
    {
        public unsafe VTable* Virtual;
        public IntPtr field0004;
        public IntPtr field0008;
        public int field000C;
        public int field0010;
        public IntPtr field0014;
        public IntPtr field0018;
        public IntPtr field001C;
        public IntPtr field0020;
        public IntPtr field0024;
        public IntPtr field0028;
        public IntPtr field002C;
        public int BaseRawCode;
        public IntPtr field0034;
        public IntPtr field0038;
        public IntPtr field003C;
        public IntPtr field0040;
        public IntPtr field0044;
        public IntPtr field0048;
        public IntPtr field004C;
        public IntPtr field0050;
        public IntPtr field0054;
        public IntPtr field0058;
        public IntPtr field005C;
        public IntPtr field0060;
        public IntPtr field0064;
        public IntPtr field0068;
        public IntPtr field006C;
        public IntPtr field0070;
        public IntPtr field0074;
        public IntPtr field0078;
        public IntPtr field007C;
        public IntPtr field0080;
        public IntPtr field0084;
        public IntPtr field0088;
        public IntPtr field008C;
        public IntPtr field0090;
        public IntPtr field0094;
        public IntPtr field0098;
        public IntPtr field009C;
        public int field00A0;
        public int field00A4;
        public IntPtr field00A8;
        public IntPtr field00AC;
        public float field00B0;
        public IntPtr field00B4;
        public IntPtr field00B8;
        public IntPtr field00BC;
        public int field00C0;
        public int field00C4;
        public IntPtr field00C8;
        public IntPtr field00CC;
        public IntPtr field00D0;
        public IntPtr field00D4;
        public IntPtr field00D8;
        public IntPtr field00DC;
        public float Defense;
        public IntPtr field00E4;
        public IntPtr field00E8;
        public IntPtr field00EC;
        public IntPtr field00F0;
        public IntPtr field00F4;
        public IntPtr field00F8;
        public IntPtr field00FC;
        public IntPtr field0100;
        public int field0104;
        public int field0108;
        public IntPtr field010C;
        public IntPtr field0110;
        public IntPtr field0114;
        public IntPtr field0118;
        public IntPtr field011C;
        public int field0120;
        public int field0124;
        public IntPtr field0128;
        public IntPtr field012C;
        public IntPtr field0130;
        public IntPtr field0134;
        public IntPtr field0138;
        public IntPtr field013C;
        public IntPtr field0140;
        public IntPtr field0144;
        public IntPtr field0148;
        public IntPtr field014C;
        public IntPtr field0150;
        public IntPtr field0154;
        public IntPtr field0158;
        public IntPtr field015C;
        public IntPtr field0160;
        public IntPtr field0164;
        public IntPtr field0168;
        public int field016C;
        public int field0170;
        public IntPtr field0174;
        public IntPtr field0178;
        public IntPtr field017C;
        public IntPtr field0180;
        public IntPtr field0184;
        public IntPtr field0188;
        public IntPtr field018C;
        public IntPtr field0190;
        public IntPtr field0194;
        public IntPtr field0198;
        public IntPtr field019C;
        public IntPtr field01A0;
        public IntPtr field01A4;
        public IntPtr field01A8;
        public IntPtr field01AC;
        public IntPtr field01B0;
        public IntPtr field01B4;
        public IntPtr field01B8;
        public IntPtr field01BC;
        public IntPtr field01C0;
        public IntPtr field01C4;
        public IntPtr field01C8;
        public IntPtr field01CC;
        public IntPtr field01D0;
        public IntPtr field01D4;
        public IntPtr field01D8;
        public int field01DC;
        public int field01E0;
        public IntPtr field01E4;
        public unsafe CAbility* AbilityAttack;
        public unsafe CAbility* AbilityMove;
        public unsafe CAbility* AbilityHero;
        public unsafe CAbility* AbilityBuild;
        public unsafe CAbility* AbilityInventory;
        public IntPtr field01FC;
        public IntPtr field0200;
        public IntPtr field0204;
        public IntPtr field0208;
        public IntPtr field020C;
        public IntPtr field0210;
        public IntPtr field0214;
        public IntPtr field0218;
        public int field021C;
        public int field0220;
        public IntPtr field0224;
        public IntPtr field0228;
        public IntPtr field022C;
        public IntPtr field0230;
        public IntPtr field0234;
        public IntPtr field0238;
        public IntPtr field023C;
        public IntPtr field0240;
        public IntPtr field0244;
        public IntPtr field0248;
        public IntPtr field024C;
        public IntPtr field0250;
        public IntPtr field0254;
        public IntPtr field0258;
        public IntPtr field025C;
        public IntPtr field0260;
        public IntPtr field0264;
        public IntPtr field0268;
        public IntPtr field026C;
        public IntPtr field0270;
        public IntPtr field0274;
        public IntPtr field0278;
        public IntPtr field027C;
        public IntPtr field0280;
        public float X;
        public float Y;
        public float Z;
        public float Facing;
        public IntPtr field0294;
        public IntPtr field0298;
        public IntPtr field029C;
        public IntPtr field02A0;
        public IntPtr field02A4;
        public IntPtr field02A8;
        public IntPtr field02AC;
        public IntPtr field02B0;
        public IntPtr field02B4;
        public IntPtr field02B8;
        public IntPtr field02BC;
        public IntPtr field02C0;
        public IntPtr field02C4;
        public IntPtr field02C8;
        public IntPtr field02CC;
        public IntPtr field02D0;
        public IntPtr field02D4;
        public IntPtr field02D8;
        public IntPtr field02DC;
        public IntPtr field02E0;
        public IntPtr field02E4;
        public IntPtr field02E8;
        public IntPtr field02EC;
        public IntPtr field02F0;
        public IntPtr field02F4;
        public IntPtr field02F8;
        public IntPtr field02FC;
        public IntPtr field0300;
        public IntPtr field0304;
        public IntPtr field0308;
        public IntPtr field030C;

        public static unsafe CUnitInternal* FromHandle(IntPtr handle)
        {
            return FastCall.Invoke<CUnit>(GameAddresses.GetUnitFromHandle, handle).AsUnsafe();
        }

        public unsafe CUnit AsSafe()
        {
            fixed (CUnitInternal* pointer = &this)
                return CUnit.FromPointer(pointer);
        }

        public unsafe IntPtr AsIntPtr()
        {
            fixed (CUnitInternal* cunitInternalPtr = &this)
                return new IntPtr((void*)cunitInternalPtr);
        }

        public unsafe CAgentInternal* ToBase()
        {
            fixed (CUnitInternal* cunitInternalPtr = &this)
                return (CAgentInternal*)cunitInternalPtr;
        }

        public unsafe CAbility* GetAbility(ObjectIdL ability)
        {
            return ThisCall.Invoke<CAbilityPtr>(GameAddresses.CUnit__GetAbility, ability, false, true, true, true).AsUnsafe();
        }

        public unsafe CAbilityAttack* GetAttackAbility()
        {
            return (CAbilityAttack*)GetAbility(new ObjectIdL("Aatk"));
        }

        public unsafe CAbility* GetMovementAbility()
        {
            return GetAbility(new ObjectIdL("Amov"));
        }

        public unsafe CAbility* GetHeroAbility()
        {
            return GetAbility(new ObjectIdL("AHer"));
        }

        public unsafe CAbility* GetBuildAbility()
        {
            return GetAbility(new ObjectIdL("ANbu"));
        }

        public unsafe CAbility* GetInventoryAbility()
        {
            return GetAbility(new ObjectIdL("AInv"));
        }

        public unsafe List<CAbilityPtr> GetAllAbilities()
        {
            List<CAbilityPtr> cabilityPtrList = new List<CAbilityPtr>();
            fixed (CUnitInternal* cunitInternalPtr = &this)
            {
                int num1 = cunitInternalPtr->field01DC & cunitInternalPtr->field01E0;
                int* a1 = &cunitInternalPtr->field01DC;
                IntPtr num2;
                if (num1 != -1 && (num2 = GameFunctions.sub_6F08AE90(a1)) != IntPtr.Zero)
                {
                    do
                    {
                        cabilityPtrList.Add(((CAbility*)(void*)num2)->AsSafe());
                        num2 = (*(int*)(void*)(num2 + 36) & *(int*)(void*)(num2 + 40)) == -1 ? IntPtr.Zero : GameFunctions.sub_6F08AE90((int*)(void*)(num2 + 36));
                    }
                    while (num2 != IntPtr.Zero);
                }
            }
            return cabilityPtrList;
        }

        public struct VTable
        {
            public unsafe IntPtr* Function;
        }
    }
}
