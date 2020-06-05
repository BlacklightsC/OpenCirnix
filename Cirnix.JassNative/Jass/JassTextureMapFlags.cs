using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Htexmapflags;")]
  [Serializable]
  public struct JassTextureMapFlags
  {
    public readonly IntPtr Handle;

    public JassTextureMapFlags(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
