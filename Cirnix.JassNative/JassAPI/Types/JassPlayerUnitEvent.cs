using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hplayerunitevent;")]
  [Serializable]
  public struct JassPlayerUnitEvent
  {
    public readonly IntPtr Handle;

    public JassPlayerUnitEvent(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
