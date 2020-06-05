using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hmapsetting;")]
  [Serializable]
  public struct JassMapSetting
  {
    public readonly IntPtr Handle;

    public JassMapSetting(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
