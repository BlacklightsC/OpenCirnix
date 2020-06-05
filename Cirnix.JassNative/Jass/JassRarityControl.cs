using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hraritycontrol;")]
  [Serializable]
  public struct JassRarityControl
  {
    public readonly IntPtr Handle;

    public JassRarityControl(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
