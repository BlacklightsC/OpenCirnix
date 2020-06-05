using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Htexttag;")]
  [Serializable]
  public struct JassTextTag
  {
    public readonly IntPtr Handle;

    public JassTextTag(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
