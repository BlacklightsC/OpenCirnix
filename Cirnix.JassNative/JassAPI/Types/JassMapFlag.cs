using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hmapflag;")]
  [Serializable]
  public struct JassMapFlag
  {
    public readonly IntPtr Handle;

    public JassMapFlag(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
