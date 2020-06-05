using System;

namespace Cirnix.JassNative.WarAPI.Types
{
  public struct StringPoolPtr
  {
    private IntPtr pointer;

    public unsafe StringPoolPtr(StringPool* pointer)
    {
      this.pointer = new IntPtr((void*) pointer);
    }

    public unsafe StringPool* AsUnsafe()
    {
      return (StringPool*) (void*) this.pointer;
    }

    public IntPtr AsIntPtr()
    {
      return this.pointer;
    }
  }
}
