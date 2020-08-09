using System.Runtime.InteropServices;

namespace Cirnix.JassNative.Runtime.Blizzard.Storm
{
    public static unsafe class SStr
    {
        [DllImport("storm.dll", EntryPoint = "#590")]
        public static extern int HashHT([In] char* input);

        [DllImport("storm.dll", EntryPoint = "#590")]
        public static extern int HashHT([In] string input);
    }
}
