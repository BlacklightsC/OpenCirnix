using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Cirnix.JassNative.Runtime.Utilities;
using Cirnix.JassNative.Runtime.Windows;
using Cirnix.JassNative.WarAPI;
using Cirnix.JassNative.WarAPI.Types;

namespace Cirnix.JassNative.JassAPI
{
    public static class Script
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate Jass* Jass__ConstructorPrototype(Jass* jass);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate IntPtr VirtualMachine__RunFunctionPrototype(VirtualMachine* vm, string functionName, int a3, int a4, int a5, int a6);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate CodeResult VirtualMachine__RunCodePrototype(VirtualMachine* vm, OpCode* op, IntPtr a3, uint opLimit, IntPtr a5);

        public unsafe delegate void VirtualMachine__RunCodeCallbackDelegate(VirtualMachine* vm, OpCode* op, IntPtr a3, uint opLimit, IntPtr a5, CodeResult result);

        private static Jass__ConstructorPrototype Jass__Constructor;
        private static VirtualMachine__RunFunctionPrototype VirtualMachine__RunFunction;
        private static VirtualMachine__RunCodePrototype VirtualMachine__RunCode;

        private static Dictionary<string, Action> Prefix = new Dictionary<string, Action>();
        private static Dictionary<string, Action> Postfix = new Dictionary<string, Action>();

        public static event VirtualMachine__RunCodeCallbackDelegate VirtualMachine__RunCodeCallback;

        public static unsafe void Initialize()
        {
            if (Kernel32.GetModuleHandle("game.dll") == IntPtr.Zero)
                throw new Exception($"Attempted to initialize {nameof(Script)} before 'game.dll' has been loaded.");
            if (!GameAddresses.IsReady)
                throw new Exception($"Attempted to initialize {nameof(Script)} before {nameof(GameAddresses)} was ready.");
            Jass__Constructor = Memory.InstallHook(GameAddresses.Jass__Constructor, new Jass__ConstructorPrototype(Jass__ConstructorHook), true, false);
            VirtualMachine__RunFunction = Memory.InstallHook(GameAddresses.VirtualMachine__RunFunction, new VirtualMachine__RunFunctionPrototype(VirtualMachine__RunFunctionHook), true, false);
            VirtualMachine__RunCode = Memory.InstallHook(GameAddresses.VirtualMachine__RunCode, new VirtualMachine__RunCodePrototype(VirtualMachine__RunCodeHook), true, false);
        }

        public static unsafe Jass* Jass { get; private set; }

        public static bool InstallPrefixHook(string functionName, Action method)
        {
            if (Prefix.ContainsKey(functionName)) return false;
            Prefix.Add(functionName, method);
            return true;
        }
        public static void RemovePrefixHook(string functionName)
        {
            Prefix.Remove(functionName);
        }

        public static bool InstallPostfixHook(string functionName, Action method)
        {
            if (Postfix.ContainsKey(functionName)) return false;
            Postfix.Add(functionName, method);
            return true;
        }
        public static void RemovePostfixHook(string functionName)
        {
            Postfix.Remove(functionName);
        }

        private static unsafe Jass* Jass__ConstructorHook(Jass* @this)
        {
            Jass* jassPtr = Jass__Constructor(@this);
            try
            {
                Jass = jassPtr;
                Trace.WriteLine($"Jass constructed: 0x{new IntPtr((void*)jassPtr).ToInt32():X8}");
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Unhandled Exception in {nameof(Script)}.{nameof(Jass__ConstructorHook)}!");
                Trace.WriteLine(ex.ToString());
            }
            return jassPtr;
        }

        private static unsafe IntPtr VirtualMachine__RunFunctionHook(VirtualMachine* virtualMachine, string functionName, int a3, int a4, int a5, int a6)
        {
            IntPtr num = IntPtr.Zero;
            try
            {
                if (Prefix.ContainsKey(functionName)) Prefix[functionName]();
                Trace.WriteLine($"Running {functionName}: 0x{new IntPtr(virtualMachine).ToInt32():X8}");
                num = VirtualMachine__RunFunction(virtualMachine, functionName, a3, a4, a5, a6);
                if (Postfix.ContainsKey(functionName)) Postfix[functionName]();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Unhandled Exception in {nameof(Script)}.{nameof(VirtualMachine__RunFunctionHook)}!");
                Trace.WriteLine(ex.ToString());
            }
            return num;
        }

        private static unsafe CodeResult VirtualMachine__RunCodeHook(VirtualMachine* vm, OpCode* op, IntPtr a3, uint opLimit, IntPtr a5)
        {
            CodeResult result = VirtualMachine__RunCode(vm, op, a3, opLimit, a5);
            try
            {
                VirtualMachine__RunCodeCallback?.Invoke(vm, op, a3, opLimit, a5, result);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Unhandled Exception in {nameof(Script)}.{nameof(VirtualMachine__RunCodeHook)}!");
                Trace.WriteLine(ex.ToString());
            }
            return result;
        }
    }
}