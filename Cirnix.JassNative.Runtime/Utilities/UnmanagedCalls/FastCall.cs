using Cirnix.JassNative.Runtime.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.Runtime.Utilities.UnmanagedCalls
{
    public static class FastCall
    {
        private static byte[] InvokeFastCallCode = new byte[]
            {
                0x5A,                           // pop edx
                0x36, 0x87, 0x54, 0x24, 0x08,   // xchg ss:[esp+08],edx
                0x58,                           // pop eax
                0x59,                           // pop ecx
                0xFF, 0xE0                      // jmp eax
            };

        private static GCHandle InvokeFastCallHandle;

        private static Dictionary<IntPtr, DynamicMethod> methods = new Dictionary<IntPtr, DynamicMethod>();

        static FastCall()
        {
            InvokeFastCallHandle = GCHandle.Alloc(InvokeFastCallCode, GCHandleType.Pinned);
            //Make the native method executable
            Kernel32.VirtualProtect(InvokeFastCallHandle.AddrOfPinnedObject(), InvokeFastCallCode.Length, 0x40, out _);
        }

        public static TReturned Invoke<TReturned>(IntPtr address, params object[] parameters) where TReturned : struct
        {
            parameters = PrependAddress(parameters, address);

            if (!methods.TryGetValue(address, out DynamicMethod method))
            {
                var returnType = typeof(TReturned);
                var paramTypes = parameters.Select(item => item.GetType()).ToArray();

                method = new DynamicMethod($"FastCall_Invoke_{(int)address:X8}", returnType, paramTypes, typeof(FastCall).Module);
                var il = method.GetILGenerator();
                for (int i = 0; i < parameters.Length; i++)
                    il.Emit(OpCodes.Ldarg, i);
                il.Emit(OpCodes.Ldc_I4, (int)InvokeFastCallHandle.AddrOfPinnedObject());
                il.Emit(OpCodes.Conv_I);
                il.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, returnType, paramTypes);
                il.Emit(OpCodes.Ret);

                methods.Add(address, method);
            }

            return (TReturned)method.Invoke(null, parameters);
        }

        private static object[] PrependAddress(object[] input, IntPtr address)
        {
            var newArray = new object[input.Length + 1];
            newArray[0] = address;
            Array.Copy(input, 0, newArray, 1, input.Length);
            return newArray;
        }
    }
}
