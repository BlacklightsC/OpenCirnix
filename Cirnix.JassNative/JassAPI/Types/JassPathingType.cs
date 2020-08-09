using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hpathingtype;")]
  [Serializable]
  public struct JassPathingType
  {
    public readonly IntPtr Handle;

    public JassPathingType(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
