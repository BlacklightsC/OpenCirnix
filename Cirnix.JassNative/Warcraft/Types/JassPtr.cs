using System;

namespace Cirnix.JassNative.WarAPI.Types
{
  public struct JassPtr
  {
    private IntPtr pointer;

    public unsafe JassPtr(Jass* pointer)
    {
      this.pointer = new IntPtr((void*) pointer);
    }

    public unsafe Jass* AsUnsafe()
    {
      return (Jass*) (void*) this.pointer;
    }

    public IntPtr AsIntPtr()
    {
      return this.pointer;
    }
  }
}
