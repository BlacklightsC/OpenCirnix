using System;

namespace Cirnix.JassNative.WarAPI.Types
{
  public struct ClassPrototypePtr
  {
    private IntPtr pointer;

    public unsafe ClassPrototypePtr(ClassPrototype* pointer)
    {
      this.pointer = new IntPtr((void*) pointer);
    }

    public unsafe ClassPrototype* AsUnsafe()
    {
      return (ClassPrototype*) (void*) this.pointer;
    }

    public IntPtr AsIntPtr()
    {
      return this.pointer;
    }
  }
}
