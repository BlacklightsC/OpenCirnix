using System;
using System.Diagnostics;

using Cirnix.JassNative.Runtime.Windows;

namespace Cirnix.JassNative.WarAPI
{
    public static class GameAddresses
    {
        public static IntPtr CUnit__GetAbility;
        private const int CUnit__GetAbilityOffset = 0x4C0C90;
        public static IntPtr GetAbilDataCacheNodeFromId;
        private const int GetAbilDataCacheNodeFromIdOffset = 0x6E06E0;
        public static IntPtr CGameUI__Constructor;
        private const int CGameUI__ConstructorOffset = 0x39B770;
        public static IntPtr CGameUI__DisplayChatMessage;
        private const int CGameUI__DisplayChatMessageOffset = 0x3A7560;
        public static IntPtr Unknown__UpdateMouse;
        private const int Unknown__UpdateMouseOffset = 0x3B64E0;
        public static IntPtr Unknown__SetState;
        private const int Unknown__SetStateOffset = 0x212370;
        public static IntPtr GetUnitFromHandle;
        private const int GetUnitFromHandleOffset = 0x2217A0;
        public static IntPtr GetTriggerFromHandle;
        private const int GetTriggerFromHandleOffset = 0x221660;
        public static IntPtr GetDestructableFromHandle;
        private const int GetDestructableFromHandleOffset = 0x21F220;
        public static IntPtr GetItemFromHandle;
        private const int GetItemFromHandleOffset = 0x21FEA0;
        public static IntPtr StringToJassStringIndex;
        private const int StringToJassStringIndexOffset = 0x22A770;
        public static IntPtr CTriggerWar3__Execute;
        private const int CTriggerWar3__ExecuteOffset = 0x2C9EA0;
        public static IntPtr JassStringManager__Resize;
        private const int JassStringManager__ResizeOffset = 0x8C4770;
        public static IntPtr InitNatives;
        private const int InitNativesOffset = 0x239C80;
        public static IntPtr BindNative;
        private const int BindNativeOffset = 0x8C2070;
        public static IntPtr Jass__Constructor;
        private const int Jass__ConstructorOffset = 0x8B9E20;
        public static IntPtr VirtualMachine__RunCode;
        private const int VirtualMachine__RunCodeOffset = 0x8D03B0;
        public static IntPtr VirtualMachine__RunFunction;
        private const int VirtualMachine__RunFunctionOffset = 0x8D1260;
        public static IntPtr GetThreadLocalStorage;
        private const int GetThreadLocalStorageOffset = 0x95DF0;
        public static IntPtr JassStringHandleToString;
        private const int JassStringHandleToStringOffset = 0x98510;
        public static IntPtr sub_6F08AE90;
        private const int sub_6F08AE90Offset = 0x8AE90;
        public static IntPtr WndProc;
        private const int WndProcOffset = 0x16F520;

        public static bool IsReady { get; private set; }

        public static event Action Ready;

        public static void Initialize()
        {
            if (Kernel32.GetModuleHandle("game.dll") == IntPtr.Zero)
                throw new Exception($"Attempted to initialize {typeof(GameAddresses).Name} before 'game.dll' has been loaded.");
            IntPtr moduleHandle = Kernel32.GetModuleHandle("game.dll");
            Trace.WriteLine("Base: 0x" + moduleHandle.ToString("X8"));
            CUnit__GetAbility = moduleHandle + CUnit__GetAbilityOffset;
            GetAbilDataCacheNodeFromId = moduleHandle + GetAbilDataCacheNodeFromIdOffset;
            CGameUI__Constructor = moduleHandle + CGameUI__ConstructorOffset;
            CGameUI__DisplayChatMessage = moduleHandle + CGameUI__DisplayChatMessageOffset;
            Unknown__UpdateMouse = moduleHandle + Unknown__UpdateMouseOffset;
            Unknown__SetState = moduleHandle + Unknown__SetStateOffset;
            GetUnitFromHandle = moduleHandle + GetUnitFromHandleOffset;
            GetTriggerFromHandle = moduleHandle + GetTriggerFromHandleOffset;
            GetDestructableFromHandle = moduleHandle + GetDestructableFromHandleOffset;
            GetItemFromHandle = moduleHandle + GetItemFromHandleOffset;
            StringToJassStringIndex = moduleHandle + StringToJassStringIndexOffset;
            CTriggerWar3__Execute = moduleHandle + CTriggerWar3__ExecuteOffset;
            JassStringManager__Resize = moduleHandle + JassStringManager__ResizeOffset;
            InitNatives = moduleHandle + InitNativesOffset;
            BindNative = moduleHandle + BindNativeOffset;
            Jass__Constructor = moduleHandle + Jass__ConstructorOffset;
            VirtualMachine__RunCode = moduleHandle + VirtualMachine__RunCodeOffset;
            VirtualMachine__RunFunction = moduleHandle + VirtualMachine__RunFunctionOffset;
            GetThreadLocalStorage = moduleHandle + GetThreadLocalStorageOffset;
            JassStringHandleToString = moduleHandle + JassStringHandleToStringOffset;
            sub_6F08AE90 = moduleHandle + sub_6F08AE90Offset;
            WndProc = moduleHandle + WndProcOffset;
            IsReady = true;
            OnReady();
        }

        private static void OnReady()
        {
            Ready?.Invoke();
        }
    }
}
