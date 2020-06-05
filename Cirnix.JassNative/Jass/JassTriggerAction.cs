using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Htriggeraction;")]
  [Serializable]
  public struct JassTriggerAction
  {
    public readonly IntPtr Handle;

    public JassTriggerAction(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
