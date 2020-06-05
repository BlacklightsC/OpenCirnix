using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hlocation;")]
  [Serializable]
  public struct JassLocation
  {
    public readonly IntPtr Handle;

    public JassLocation(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
