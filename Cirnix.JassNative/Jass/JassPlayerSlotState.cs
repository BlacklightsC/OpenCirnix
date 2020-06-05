using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hplayerslotstate;")]
  [Serializable]
  public struct JassPlayerSlotState
  {
    public static JassPlayerSlotState Empty = Natives.ConvertPlayerSlotState(0);
    public static JassPlayerSlotState Playing = Natives.ConvertPlayerSlotState(1);
    public static JassPlayerSlotState Left = Natives.ConvertPlayerSlotState(2);
    public readonly IntPtr Handle;

    public JassPlayerSlotState(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
