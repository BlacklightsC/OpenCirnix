using System;
using System.Dynamic;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.Runtime.Utilities
{
    public class DynamicModule : DynamicObject
    {
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr module, string procName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr module, int procOrdinal);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string moduleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
        static extern IntPtr LoadLibrary(string fileName);

        public DynamicModule(string moduleName)
        {
            Module = GetModuleHandle(moduleName);
            if (Module == IntPtr.Zero)
                Module = LoadLibrary(moduleName);
            if (Module == IntPtr.Zero)
                throw new ArgumentException("Could not find the specified module", "module");
        }

        public DynamicModule(IntPtr module)
        {
            Module = module;
        }

        public IntPtr Module { private set; get; }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            Console.WriteLine("TryGetMember");
            if (binder.Name.StartsWith("Ordinal_"))
                result = GetProcAddress(Module, int.Parse(binder.Name.Replace("Ordinal_", "")));
            else if (binder.Name.StartsWith("Sub_"))
                result = Module + Convert.ToInt32(binder.Name.Replace("Sub_", ""), 16);
            else
                result = GetProcAddress(Module, binder.Name);
            if ((IntPtr)result != IntPtr.Zero)
                return true;
            return base.TryGetMember(binder, out result);
        }
    }
}
