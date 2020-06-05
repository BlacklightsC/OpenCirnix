using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hsound;")]
  [Serializable]
  public struct JassSound
  {
    public readonly IntPtr Handle;

    public JassSound(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
