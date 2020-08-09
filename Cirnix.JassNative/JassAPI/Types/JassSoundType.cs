using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hsoundtype;")]
  [Serializable]
  public struct JassSoundType
  {
    public readonly IntPtr Handle;

    public JassSoundType(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
