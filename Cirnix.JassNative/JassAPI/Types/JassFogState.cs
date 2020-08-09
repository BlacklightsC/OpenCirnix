using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hfogstate;")]
    [Serializable]
    public struct JassFogState
    {
        public static JassFogState Masked = Natives.ConvertFogState(1);
        public static JassFogState Fogged = Natives.ConvertFogState(2);
        public static JassFogState Visible = Natives.ConvertFogState(4);
        public readonly IntPtr Handle;

        public JassFogState(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}