using System;
using System.Runtime.InteropServices;

namespace Cirnix.JassNative.WarAPI.Types
{
  [StructLayout(LayoutKind.Sequential, Size = 20)]
  public struct ClassPrototype
  {
    public int ClassSize;
    public int BatchSize;
    public int ElementsCreatedCount;
    public IntPtr MemoryAreas;
    public IntPtr FirstFreeElement;

    public unsafe ClassPrototypePtr AsSafe()
    {
      fixed (ClassPrototype* pointer = &this)
        return new ClassPrototypePtr(pointer);
    }

    public unsafe IntPtr AsIntPtr()
    {
      fixed (ClassPrototype* classPrototypePtr = &this)
        return new IntPtr((void*) classPrototypePtr);
    }
  }
}
