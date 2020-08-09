using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
    [StructLayout(LayoutKind.Explicit, Size = 8, Pack = 1)]
    public struct OpCode
    {
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(0)]
        public byte R1;
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(0)]
        public byte NFArg;
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(1)]
        public byte R2;
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(1)]
        public byte UseReturn;
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(2)]
        public byte R3;
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(2)]
        public JassType ReturnType;
        [MarshalAs(UnmanagedType.U1)]
        [FieldOffset(3)]
        public OpCodeType OpType;
        [MarshalAs(UnmanagedType.U4)]
        [FieldOffset(4)]
        public int Argument;
        [FieldOffset(4)]
        public unsafe OpCode* Destination;
    }
}