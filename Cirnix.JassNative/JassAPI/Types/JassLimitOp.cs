using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hlimitop;")]
  [Serializable]
  public struct JassLimitOp
  {
    public static JassLimitOp LessThan = Natives.ConvertLimitOp(0);
    public static JassLimitOp LessThanOrEqual = Natives.ConvertLimitOp(1);
    public static JassLimitOp Equal = Natives.ConvertLimitOp(2);
    public static JassLimitOp GreaterThanOrEqual = Natives.ConvertLimitOp(3);
    public static JassLimitOp GreaterThan = Natives.ConvertLimitOp(4);
    public static JassLimitOp NotEqual = Natives.ConvertLimitOp(5);
    public readonly IntPtr Handle;

    public JassLimitOp(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
