using Cirnix.JassNative.WarAPI.Types;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Cirnix.JassNative.Runtime.Utilities;
using Cirnix.JassNative.Runtime.Utilities.UnmanagedCalls;
using Cirnix.JassNative.Runtime.Windows;

namespace Cirnix.JassNative.WarAPI
{
    public static class GameFunctions
    {
        public static bool IsReady { get; private set; }

        public static event Action Ready;

        public static void Initialize()
        {
            if (Kernel32.GetModuleHandle("game.dll") == IntPtr.Zero)
                throw new Exception("Attempted to initialize " + typeof(GameFunctions).Name + " before 'game.dll' has been loaded.");
            if (!GameAddresses.IsReady)
                throw new Exception("Attempted to initialize " + typeof(GameFunctions).Name + " before " + typeof(GameAddresses).Name + " was ready.");
            IsReady = true;
            OnReady();
        }

        private static void OnReady()
        {
            Ready?.Invoke();
        }

        //public static AbilDataCacheNodePtr GetAbilDataCacheNodeFromId(ObjectIdL id)
        //{
        //    return FastCall.Invoke<AbilDataCacheNodePtr>(GameAddresses.GetAbilDataCacheNodeFromId, (object)id);
        //}

        //public static IntPtr CGameUI__Constructor(CGameUI @this)
        //{
        //    return ThisCall.Invoke<IntPtr>(GameAddresses.CGameUI__Constructor, (object)@this);
        //}

        //public static unsafe IntPtr CGameUI__DisplayChatMessage(CGameUI* @this, int sender, string message, ChatRecipients recipients, float duration)
        //{
        //    return ThisCall.Invoke<IntPtr>(GameAddresses.CGameUI__DisplayChatMessage, (IntPtr)((void*)@this), sender, message, recipients, duration);
        //}

        //public static bool Unknown__UpdateMouse(IntPtr @this, float uiX, float uiY, IntPtr terrainPtr, IntPtr a4)
        //{
        //    return ThisCall.Invoke<bool>(GameAddresses.Unknown__UpdateMouse, @this, uiX, uiY, terrainPtr, a4);
        //}

        public static int Unknown__SetState(IntPtr @this, bool endMap, bool endEngine)
        {
            return ThisCall.Invoke<int>(GameAddresses.Unknown__SetState, @this, endMap, endEngine);
        }

        //public static CTriggerWar3Ptr GetTriggerFromHandle(IntPtr trigger)
        //{
        //    return FastCall.Invoke<CTriggerWar3Ptr>(GameAddresses.GetTriggerFromHandle, (object)trigger);
        //}

        //public static CDestructablePtr GetDestructableFromHandle(IntPtr destructable)
        //{
        //    return FastCall.Invoke<CDestructablePtr>(GameAddresses.GetDestructableFromHandle, (object)destructable);
        //}

        //public static CItemPtr GetItemFromHandle(IntPtr item)
        //{
        //    return FastCall.Invoke<CItemPtr>(GameAddresses.GetItemFromHandle, (object)item);
        //}

        public static int StringToJassStringIndex(string str)
        {
            return FastCall.Invoke<int>(GameAddresses.StringToJassStringIndex, (object)Memory.StringAsPtr(str));
        }

        //public static void CTriggerWar3__ExecutePrototype(CTriggerWar3Ptr @this, IntPtr a2)
        //{
        //    ThisCall.Invoke<IntPtr>(GameAddresses.CTriggerWar3__Execute, @this, a2);
        //}

        //public static unsafe IntPtr JassStringManager__ResizePrototype(JassStringManager* @this, uint newSize)
        //{
        //    return ThisCall.Invoke<IntPtr>(GameAddresses.JassStringManager__Resize, new IntPtr((void*)@this), newSize);
        //}

        public static IntPtr InitNatives()
        {
            return StdCall.Invoke<IntPtr>(GameAddresses.InitNatives);
        }

        public static void BindNative(IntPtr function, string name, string prototype)
        {
            FastCall.Invoke<IntPtr>(GameAddresses.BindNative, function, Memory.StringAsPtr(name), Memory.StringAsPtr(prototype));
        }

        public static void BindNative(Delegate function, string name, string prototype)
        {
            FastCall.Invoke<IntPtr>(GameAddresses.BindNative, Utility.FunctionAsPtr(function), Memory.StringAsPtr(name), Memory.StringAsPtr(prototype));
        }

        public static JassPtr Jass__Constructor(JassPtr @this)
        {
            return ThisCall.Invoke<JassPtr>(GameAddresses.Jass__Constructor, (object)@this);
        }

        public static unsafe CodeResult VirtualMachine__RunCode(VirtualMachine* @this, IntPtr opCode, IntPtr a3, uint opLimit, IntPtr a5)
        {
            return ThisCall.Invoke<CodeResult>(GameAddresses.VirtualMachine__RunCode, new IntPtr((void*)@this), opCode, a3, opLimit, a5);
        }

        public static unsafe IntPtr VirtualMachine__RunFunction(VirtualMachine* @this, string functionName, IntPtr a3, IntPtr a4, IntPtr a5, IntPtr a6)
        {
            return ThisCall.Invoke<IntPtr>(GameAddresses.VirtualMachine__RunFunction, new IntPtr((void*)@this), functionName, a3, a4, a5, a6);
        }

        public static unsafe ThreadLocalStorage* GetThreadLocalStorage()
        {
            return (ThreadLocalStorage*)(void*)StdCall.Invoke<IntPtr>(GameAddresses.GetThreadLocalStorage);
        }

        public static string JassStringHandleToString(IntPtr jassStringHandle)
        {
            return Memory.PtrAsString(FastCall.Invoke<IntPtr>(GameAddresses.JassStringHandleToString, (object)jassStringHandle));
        }

        //public static unsafe IntPtr sub_6F4786B0(int* a1)
        //{
        //    return FastCall.Invoke<IntPtr>(GameAddresses.sub_6F044150, (object)new IntPtr((void*)a1));
        //}

        //public static IntPtr WndProc(IntPtr hWnd, uint msg, uint wParam, uint lParam)
        //{
        //    return StdCall.Invoke<IntPtr>(GameAddresses.WndProc, hWnd, msg, wParam, lParam);
        //}

        public static unsafe IntPtr JassStringIndexToJassStringHandle(int jassStringIndex)
        {
            return Marshal.ReadIntPtr(Marshal.ReadIntPtr(Marshal.ReadIntPtr(Marshal.ReadIntPtr(GetThreadLocalStorage()->Jass.AsIntPtr(), 0xC)), 0x2874), 8) + 8 + 0x10 * jassStringIndex;
        }
    }
}