using System;

namespace Cirnix.JassNative.WarAPI.Types
{
  public struct StringNodePtr
  {
    private IntPtr pointer;

    public unsafe StringNodePtr(StringNode* pointer)
    {
      this.pointer = new IntPtr((void*) pointer);
    }

    public unsafe StringNode* AsUnsafe()
    {
      return (StringNode*) (void*) this.pointer;
    }

    public IntPtr AsIntPtr()
    {
      return this.pointer;
    }
  }
}
