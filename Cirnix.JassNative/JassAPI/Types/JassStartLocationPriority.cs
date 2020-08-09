using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hstartlocprio;")]
  [Serializable]
  public struct JassStartLocationPriority
  {
    public readonly IntPtr Handle;

    public JassStartLocationPriority(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
