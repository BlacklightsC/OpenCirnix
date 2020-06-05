using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hweapontype;")]
  [Serializable]
  public struct JassWeaponType
  {
    public readonly IntPtr Handle;

    public JassWeaponType(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
