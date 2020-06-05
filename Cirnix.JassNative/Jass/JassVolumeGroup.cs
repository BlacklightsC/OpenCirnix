using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hvolumegroup;")]
  [Serializable]
  public struct JassVolumeGroup
  {
    public readonly IntPtr Handle;

    public JassVolumeGroup(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
