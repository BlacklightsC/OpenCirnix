using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hlightning;")]
  [Serializable]
  public struct JassLightning
  {
    public readonly IntPtr Handle;

    public JassLightning(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
