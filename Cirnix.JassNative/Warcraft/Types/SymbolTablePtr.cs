using System;

namespace Cirnix.JassNative.WarAPI.Types
{
  public struct SymbolTablePtr
  {
    private IntPtr pointer;

    public unsafe SymbolTablePtr(SymbolTable* pointer)
    {
      this.pointer = new IntPtr((void*) pointer);
    }

    public unsafe SymbolTable* AsUnsafe()
    {
      return (SymbolTable*) (void*) this.pointer;
    }

    public IntPtr AsIntPtr()
    {
      return this.pointer;
    }
  }
}
