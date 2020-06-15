using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hconditionfunc;")]
    [Serializable]
    public struct JassConditionFunction
    {
        public readonly IntPtr Handle;

        public JassConditionFunction(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}