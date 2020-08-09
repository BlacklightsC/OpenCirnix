using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hwidgetevent;")]
  [Serializable]
  public struct JassWidgetEvent
  {
    public readonly IntPtr Handle;

    public JassWidgetEvent(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
