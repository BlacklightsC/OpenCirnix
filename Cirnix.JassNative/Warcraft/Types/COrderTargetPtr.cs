using System;

namespace Cirnix.JassNative.WarAPI.Types
{
  public struct COrderTargetPtr
  {
    private IntPtr pointer;

    public unsafe COrderTargetPtr(COrderTarget* pointer)
    {
      this.pointer = new IntPtr((void*) pointer);
    }

    public unsafe COrderTarget* AsUnsafe()
    {
      return (COrderTarget*) (void*) this.pointer;
    }

    public IntPtr AsIntPtr()
    {
      return this.pointer;
    }
  }
}
