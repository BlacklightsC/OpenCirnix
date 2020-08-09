using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hmultiboarditem;")]
  [Serializable]
  public struct JassMultiboardItem
  {
    public readonly IntPtr Handle;

    public JassMultiboardItem(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
