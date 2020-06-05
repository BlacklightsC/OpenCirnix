using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hmapvisibility;")]
  [Serializable]
  public struct JassMapVisibility
  {
    public readonly IntPtr Handle;

    public JassMapVisibility(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
