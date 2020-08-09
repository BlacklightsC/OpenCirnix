using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hplayerscore;")]
  [Serializable]
  public struct JassPlayerScore
  {
    public readonly IntPtr Handle;

    public JassPlayerScore(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
