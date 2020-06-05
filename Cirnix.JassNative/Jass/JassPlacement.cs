using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hplacement;")]
  [Serializable]
  public struct JassPlacement
  {
    public readonly IntPtr Handle;

    public JassPlacement(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
