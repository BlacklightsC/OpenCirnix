using System;

namespace Cirnix.JassNative.JassAPI
{
  [JassType("Hweathereffect;")]
  [Serializable]
  public struct JassWeatherEffect
  {
    public readonly IntPtr Handle;

    public JassWeatherEffect(IntPtr handle)
    {
      this.Handle = handle;
    }
  }
}
