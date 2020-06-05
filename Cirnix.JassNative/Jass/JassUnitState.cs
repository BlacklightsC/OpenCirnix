using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hunitstate;")]
  [Serializable]
  public struct JassUnitState
  {
    public static readonly JassUnitState Life = Natives.ConvertUnitState(0);
    public static readonly JassUnitState MaxLife = Natives.ConvertUnitState(1);
    public static readonly JassUnitState Mana = Natives.ConvertUnitState(2);
    public static readonly JassUnitState MaxMana = Natives.ConvertUnitState(3);
    public readonly IntPtr Handle;

    public JassUnitState(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
