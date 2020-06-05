using System;

namespace Cirnix.JassNative.WarAPI.Types
{
  public struct AbilityLevelDataPtr
  {
    private IntPtr pointer;

    public unsafe AbilityLevelDataPtr(AbilityLevelData* pointer)
    {
      this.pointer = new IntPtr((void*) pointer);
    }

    public unsafe AbilityLevelData* AsUnsafe()
    {
      return (AbilityLevelData*) (void*) pointer;
    }

    public IntPtr AsIntPtr()
    {
      return pointer;
    }
  }
}
