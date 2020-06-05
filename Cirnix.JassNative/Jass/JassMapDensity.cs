using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hmapdensity;")]
  [Serializable]
  public struct JassMapDensity
  {
    public readonly IntPtr Handle;

    public JassMapDensity(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
