using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hwidget;")]
  [Serializable]
  public struct JassWidget
  {
    public readonly IntPtr Handle;

    public JassWidget(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
