using System;
using System.Runtime.InteropServices;
using Cirnix.JassNative.Runtime.Utilities;

namespace Cirnix.JassNative.WarAPI.Types
{
  [StructLayout(LayoutKind.Sequential, Size = 24)]
  public struct StringNode
  {
    public IntPtr field0000;
    public IntPtr field0004;
    public IntPtr field0008;
    public IntPtr field0010;
    public IntPtr field0014;
    public IntPtr ValuePtr;

    public string Value
    {
      get
      {
        return Memory.ReadString(this.ValuePtr);
      }
    }

    public unsafe StringNodePtr AsSafe()
    {
      fixed (StringNode* pointer = &this)
        return new StringNodePtr(pointer);
    }

    public unsafe IntPtr AsIntPtr()
    {
      fixed (StringNode* stringNodePtr = &this)
        return new IntPtr((void*) stringNodePtr);
    }
  }
}
