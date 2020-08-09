using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Htrackable;")]
  [Serializable]
  public struct JassTrackable
  {
    public readonly IntPtr Handle;

    public JassTrackable(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
