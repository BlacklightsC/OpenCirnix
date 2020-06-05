using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hquest;")]
  [Serializable]
  public struct JassQuest
  {
    public readonly IntPtr Handle;

    public JassQuest(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
