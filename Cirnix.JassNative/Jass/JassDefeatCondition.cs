using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hdefeatcondition;")]
    [Serializable]
    public struct JassDefeatCondition
    {
        public readonly IntPtr Handle;

        public JassDefeatCondition(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}