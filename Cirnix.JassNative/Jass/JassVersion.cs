using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hversion;")]
  [Serializable]
  public struct JassVersion
  {
    public readonly IntPtr Handle;

    public JassVersion(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
