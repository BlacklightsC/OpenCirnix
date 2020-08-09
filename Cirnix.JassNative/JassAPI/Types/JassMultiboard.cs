using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hmultiboard;")]
  [Serializable]
  public struct JassMultiboard
  {
    public readonly IntPtr Handle;

    public JassMultiboard(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
