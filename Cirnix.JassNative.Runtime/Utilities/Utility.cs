using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.Runtime.Utilities
{
    public static class Utility
    {
        public static T PtrAsFunction<T>(IntPtr address) where T : class
        {
            if (typeof(Delegate).IsAssignableFrom(typeof(T)))
                return (T)(object)Marshal.GetDelegateForFunctionPointer(address, typeof(T));
            throw new InvalidOperationException("Generic T is not a delegate type");
        }

        public static T PtrAsFunction<T>(IntPtr address, int offset) where T : class
        {
            return PtrAsFunction<T>(address + offset);
        }

        public static IntPtr FunctionAsPtr(Delegate function)
        {
            return Marshal.GetFunctionPointerForDelegate(function);
        }
    }
}
