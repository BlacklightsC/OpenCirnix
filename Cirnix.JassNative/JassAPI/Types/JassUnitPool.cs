using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hunitpool;")]
  [Serializable]
  public struct JassUnitPool
  {
    public readonly IntPtr Handle;

    public JassUnitPool(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
