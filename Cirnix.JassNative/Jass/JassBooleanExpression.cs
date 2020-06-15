using System;

namespace Cirnix.JassNative.JassAPI
{
    [JassType("Hboolexpr;")]
    [Serializable]
    public struct JassBooleanExpression
    {
        public static JassBooleanExpression None = new JassBooleanExpression(IntPtr.Zero);
        public readonly IntPtr Handle;

        public JassBooleanExpression(IntPtr handle)
        {
            this.Handle = handle;
        }
    }
}