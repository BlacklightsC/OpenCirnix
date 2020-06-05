using System;

namespace Cirnix.JassNative.WarAPI.Types
{
  public struct CTriggerWar3Ptr
  {
    private IntPtr pointer;

    //public static CTriggerWar3Ptr FromHandle(IntPtr trigger)
    //{
    //  return GameFunctions.GetTriggerFromHandle(trigger);
    //}

    public unsafe CTriggerWar3Ptr(CTriggerWar3* pointer)
    {
      this.pointer = new IntPtr((void*) pointer);
    }

    public unsafe CTriggerWar3* AsUnsafe()
    {
      return (CTriggerWar3*) (void*) this.pointer;
    }

    public IntPtr AsIntPtr()
    {
      return this.pointer;
    }

    public override int GetHashCode()
    {
      return (int) this.AsIntPtr();
    }
  }
}
