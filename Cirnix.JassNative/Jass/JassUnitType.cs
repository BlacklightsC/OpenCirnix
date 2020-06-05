using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hunittype;")]
  [Serializable]
  public struct JassUnitType
  {
    public readonly IntPtr Handle;

    public JassUnitType(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
