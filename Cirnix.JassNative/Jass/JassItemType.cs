using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hitemtype;")]
  [Serializable]
  public struct JassItemType
  {
    public static JassItemType Permanent = Natives.ConvertItemType(0);
    public static JassItemType Charged = Natives.ConvertItemType(1);
    public static JassItemType PowerUp = Natives.ConvertItemType(2);
    public static JassItemType Artifact = Natives.ConvertItemType(3);
    public static JassItemType Purchasable = Natives.ConvertItemType(4);
    public static JassItemType Campaign = Natives.ConvertItemType(5);
    public static JassItemType Miscellaneous = Natives.ConvertItemType(6);
    public static JassItemType Unknown = Natives.ConvertItemType(7);
    public static JassItemType Any = Natives.ConvertItemType(8);
    public readonly IntPtr Handle;

    public JassItemType(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
