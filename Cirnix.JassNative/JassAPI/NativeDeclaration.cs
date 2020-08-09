using System;

using Cirnix.JassNative.Runtime.Utilities;

namespace Cirnix.JassNative.JassAPI
{
    public class NativeDeclaration
    {
        internal readonly IntPtr FunctionPtr;
        public readonly Delegate Function;
        public readonly string Name;
        public readonly string Prototype;

        public NativeDeclaration(IntPtr address)
        {
            this.Prototype = Memory.ReadString(Memory.Read<IntPtr>(address, 1));
            this.Name = Memory.ReadString(Memory.Read<IntPtr>(address, 6));
            this.FunctionPtr = Memory.Read<IntPtr>(address, 11);
        }

        public NativeDeclaration(IntPtr function, string name, string prototype)
        {
            this.FunctionPtr = function;
            this.Name = name;
            this.Prototype = prototype;
        }

        public NativeDeclaration(Delegate function, string name, string prototype)
        {
            this.Function = function;
            this.FunctionPtr = Utility.FunctionAsPtr(function);
            this.Name = name;
            this.Prototype = prototype;
        }

        public T ToDelegate<T>() where T : class
        {
            return Utility.PtrAsFunction<T>(this.FunctionPtr);
        }
    }
}
