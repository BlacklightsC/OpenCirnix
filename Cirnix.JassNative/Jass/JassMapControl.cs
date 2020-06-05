using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hmapcontrol;")]
  [Serializable]
  public struct JassMapControl
  {
    public static JassMapControl User = Natives.ConvertMapControl(0);
    public static JassMapControl Computer = Natives.ConvertMapControl(1);
    public static JassMapControl Rescuable = Natives.ConvertMapControl(2);
    public static JassMapControl Neutral = Natives.ConvertMapControl(3);
    public static JassMapControl Creep = Natives.ConvertMapControl(4);
    public static JassMapControl None = Natives.ConvertMapControl(5);
    public readonly IntPtr Handle;

    public JassMapControl(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
