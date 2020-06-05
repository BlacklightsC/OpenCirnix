using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hplayerevent;")]
  [Serializable]
  public struct JassPlayerEvent
  {
    public static JassPlayerEvent StateLimit = Natives.ConvertPlayerEvent(11);
    public static JassPlayerEvent AllianceChanged = Natives.ConvertPlayerEvent(12);
    public static JassPlayerEvent Defeat = Natives.ConvertPlayerEvent(13);
    public static JassPlayerEvent Victory = Natives.ConvertPlayerEvent(14);
    public static JassPlayerEvent Leave = Natives.ConvertPlayerEvent(15);
    public static JassPlayerEvent Chat = Natives.ConvertPlayerEvent(16);
    public static JassPlayerEvent EndCinematic = Natives.ConvertPlayerEvent(17);
    public static JassPlayerEvent ArrowLeftDown = Natives.ConvertPlayerEvent(261);
    public static JassPlayerEvent ArrowLeftUp = Natives.ConvertPlayerEvent(262);
    public static JassPlayerEvent ArrowRightDown = Natives.ConvertPlayerEvent(263);
    public static JassPlayerEvent ArrowRightUp = Natives.ConvertPlayerEvent(264);
    public static JassPlayerEvent ArrowDownDown = Natives.ConvertPlayerEvent(265);
    public static JassPlayerEvent ArrowDownUp = Natives.ConvertPlayerEvent(266);
    public static JassPlayerEvent ArrowUpDown = Natives.ConvertPlayerEvent(267);
    public static JassPlayerEvent ArrowUpUp = Natives.ConvertPlayerEvent(268);
    public readonly IntPtr Handle;

    public JassPlayerEvent(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
