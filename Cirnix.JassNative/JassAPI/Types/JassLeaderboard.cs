using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hleaderboard;")]
  [Serializable]
  public struct JassLeaderboard
  {
    public readonly IntPtr Handle;

    public JassLeaderboard(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
