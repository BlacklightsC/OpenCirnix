using System;
using System.Diagnostics;
using Cirnix.JassNative.Runtime.Windows;

namespace Cirnix.JassNative.WarAPI
{
    public static class GameAddresses
    {
        //public static IntPtr CUnit__GetAbility;
        //private const int CUnit__GetAbilityOffset = 0x46F440;
        //public static IntPtr GetAbilDataCacheNodeFromId;
        //private const int GetAbilDataCacheNodeFromIdOffset = 0x68EDF0;
        //public static IntPtr CGameUI__Constructor;
        //private const int CGameUI__ConstructorOffset = 0x349FA0;
        //public static IntPtr CGameUI__DisplayChatMessage;
        //private const int CGameUI__DisplayChatMessageOffset = 0x355CF0;
        //public static IntPtr Unknown__UpdateMouse;
        //private const int Unknown__UpdateMouseOffset = 0x364C40;
        public static IntPtr Unknown__SetState;
        private const int Unknown__SetStateOffset = 0x212370;           // Found
        //public static IntPtr GetUnitFromHandle;
        //private const int GetUnitFromHandleOffset = 0x1D1550;
        //public static IntPtr GetTriggerFromHandle;
        //private const int GetTriggerFromHandleOffset = 0x1D1410;
        //public static IntPtr GetDestructableFromHandle;
        //private const int GetDestructableFromHandleOffset = 0x1CEFD0;
        //public static IntPtr GetItemFromHandle;
        //private const int GetItemFromHandleOffset = 0x1CFC50;
        public static IntPtr StringToJassStringIndex;
        private const int StringToJassStringIndexOffset = 0x22A770;     // Found
        //public static IntPtr CTriggerWar3__Execute;
        //private const int CTriggerWar3__ExecuteOffset = 0x279D30;
        //public static IntPtr JassStringManager__Resize;
        //private const int JassStringManager__ResizeOffset = 0x7E5E10;
        public static IntPtr InitNatives;
        private const int InitNativesOffset = 0x239C80;                 // Found
        public static IntPtr BindNative;
        private const int BindNativeOffset = 0x8C2070;                  // Found
        public static IntPtr Jass__Constructor;
        private const int Jass__ConstructorOffset = 0x8A9662;           // Found, Probably.
        public static IntPtr VirtualMachine__RunCode;
        private const int VirtualMachine__RunCodeOffset = 0x8D03B0;     // Found
        public static IntPtr VirtualMachine__RunFunction;
        private const int VirtualMachine__RunFunctionOffset = 0x8D1260; // Found
        public static IntPtr GetThreadLocalStorage;
        private const int GetThreadLocalStorageOffset = 0x95DF0;        // Found
        public static IntPtr JassStringHandleToString;
        private const int JassStringHandleToStringOffset = 0x98510;     // Found
        //public static IntPtr sub_6F044150;
        //private const int sub_6F044150Offset = 0x44150;
        //public static IntPtr WndProc;
        //private const int WndProcOffset = 0xEC940;


        public static IntPtr GetThreadLocalStorageStorm;
        public static bool IsReady { get; private set; }

        public static event Action Ready;

        public static void Initialize()
        {
            if (Kernel32.GetModuleHandle("game.dll") == IntPtr.Zero)
                throw new Exception("Attempted to initialize " + typeof(GameAddresses).Name + " before 'game.dll' has been loaded.");
            IntPtr moduleHandle = Kernel32.GetModuleHandle("game.dll");
            Trace.WriteLine("Base: 0x" + moduleHandle.ToString("X8"));
            //GameAddresses.CUnit__GetAbility = moduleHandle + CUnit__GetAbilityOffset;
            //GameAddresses.GetAbilDataCacheNodeFromId = moduleHandle + GetAbilDataCacheNodeFromIdOffset;
            //GameAddresses.CGameUI__Constructor = moduleHandle + CGameUI__ConstructorOffset;
            //GameAddresses.CGameUI__DisplayChatMessage = moduleHandle + CGameUI__DisplayChatMessageOffset;
            //GameAddresses.Unknown__UpdateMouse = moduleHandle + Unknown__UpdateMouseOffset;
            GameAddresses.Unknown__SetState = moduleHandle + Unknown__SetStateOffset;                       // Found
            //GameAddresses.GetUnitFromHandle = moduleHandle + GetUnitFromHandleOffset;
            //GameAddresses.GetTriggerFromHandle = moduleHandle + GetTriggerFromHandleOffset;
            //GameAddresses.GetDestructableFromHandle = moduleHandle + GetDestructableFromHandleOffset;
            //GameAddresses.GetItemFromHandle = moduleHandle + GetItemFromHandleOffset;
            GameAddresses.StringToJassStringIndex = moduleHandle + StringToJassStringIndexOffset;           // Found
            //GameAddresses.CTriggerWar3__Execute = moduleHandle + CTriggerWar3__ExecuteOffset;
            //GameAddresses.JassStringManager__Resize = moduleHandle + JassStringManager__ResizeOffset;
            GameAddresses.InitNatives = moduleHandle + InitNativesOffset;                                   // Found
            GameAddresses.BindNative = moduleHandle + BindNativeOffset;                                     // Found
            GameAddresses.Jass__Constructor = moduleHandle + Jass__ConstructorOffset;                       // Found, Probably.
            GameAddresses.VirtualMachine__RunCode = moduleHandle + VirtualMachine__RunCodeOffset;           // Found
            GameAddresses.VirtualMachine__RunFunction = moduleHandle + VirtualMachine__RunFunctionOffset;   // Found
            GameAddresses.GetThreadLocalStorage = moduleHandle + GetThreadLocalStorageOffset;               // Found
            GameAddresses.JassStringHandleToString = moduleHandle + JassStringHandleToStringOffset;         // Found
            //GameAddresses.sub_6F044150 = moduleHandle + sub_6F044150Offset;
            //GameAddresses.WndProc = moduleHandle + WndProcOffset;
            IntPtr StormModuleHandle = Kernel32.GetModuleHandle("storm.dll");
            Trace.WriteLine("StormBase: 0x" + StormModuleHandle.ToString("X8"));
            GetThreadLocalStorageStorm = StormModuleHandle + 0x581FC;
            GameAddresses.IsReady = true;
            GameAddresses.OnReady();
        }

        private static void OnReady()
        {
            Ready?.Invoke();
        }
    }
}
