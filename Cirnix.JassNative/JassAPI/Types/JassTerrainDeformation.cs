using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hterraindeformation;")]
  [Serializable]
  public struct JassTerrainDeformation
  {
    public readonly IntPtr Handle;

    public JassTerrainDeformation(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
