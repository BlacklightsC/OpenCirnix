using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hquestitem;")]
  [Serializable]
  public struct JassQuestItem
  {
    public readonly IntPtr Handle;

    public JassQuestItem(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
