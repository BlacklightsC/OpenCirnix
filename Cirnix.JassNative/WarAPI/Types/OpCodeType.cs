namespace Cirnix.JassNative.WarAPI.Types
{
    public enum OpCodeType : byte
    {
        EndProgram = 1,
        Function = 3,
        EndFunction = 4,
        Local = 5,
        Global = 6,
        Constant = 7,
        PopFuncArg = 8,
        CleanStack = 11, // 0x0B
        Literal = 12, // 0x0C
        SetRet = 13, // 0x0D
        GetVar = 14, // 0x0E
        Code = 15, // 0x0F
        GetArray = 16, // 0x10
        SetVar = 17, // 0x11
        SetArray = 18, // 0x12
        Push = 19, // 0x13
        SetRight = 20, // 0x14
        Native = 21, // 0x15
        JassCall = 22, // 0x16
        I2R = 23, // 0x17
        And = 24, // 0x18
        Or = 25, // 0x19
        Equal = 26, // 0x1A
        NotEqual = 27, // 0x1B
        LesserEqual = 28, // 0x1C
        GreaterEqual = 29, // 0x1D
        Lesser = 30, // 0x1E
        Greater = 31, // 0x1F
        Add = 32, // 0x20
        Sub = 33, // 0x21
        Mul = 34, // 0x22
        Div = 35, // 0x23
        Modulo = 36, // 0x24
        Negate = 37, // 0x25
        Not = 38, // 0x26
        Return = 39, // 0x27
        JumpTarget = 40, // 0x28
        JumpIfTrue = 41, // 0x29
        JumpIfFalse = 42, // 0x2A
        Jump = 43, // 0x2B
    }
}