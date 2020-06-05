using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hrace;")]
  [Serializable]
  public struct JassRace
  {
    public readonly IntPtr Handle;

    public JassRace(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
