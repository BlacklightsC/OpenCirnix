using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Htriggercondition;")]
    [Serializable]
    public struct JassTriggerCondition
    {
        public readonly IntPtr Handle;

        public JassTriggerCondition(IntPtr handle)
        {
            Handle = handle;
        }
    }
}