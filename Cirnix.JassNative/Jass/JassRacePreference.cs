using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hracepreference;")]
  [Serializable]
  public struct JassRacePreference
  {
    public static JassRacePreference Human = Natives.ConvertRacePref(1);
    public static JassRacePreference Orc = Natives.ConvertRacePref(2);
    public static JassRacePreference NightElf = Natives.ConvertRacePref(4);
    public static JassRacePreference Undead = Natives.ConvertRacePref(8);
    public static JassRacePreference Demon = Natives.ConvertRacePref(16);
    public static JassRacePreference Random = Natives.ConvertRacePref(32);
    public static JassRacePreference UserSelectable = Natives.ConvertRacePref(64);
    public readonly IntPtr Handle;

    public JassRacePreference(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
