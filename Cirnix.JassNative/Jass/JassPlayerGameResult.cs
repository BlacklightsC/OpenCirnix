using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hplayergameresult;")]
  [Serializable]
  public struct JassPlayerGameResult
  {
    public readonly IntPtr Handle;

    public JassPlayerGameResult(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
