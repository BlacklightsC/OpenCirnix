using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hunitevent;")]
  [Serializable]
  public struct JassUnitEvent
  {
    public readonly IntPtr Handle;

    public JassUnitEvent(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
