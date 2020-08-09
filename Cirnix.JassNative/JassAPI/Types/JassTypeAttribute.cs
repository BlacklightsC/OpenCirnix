using System;

namespace Cirnix.JassNative.JassAPI
{
    [AttributeUsage(AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    internal sealed class JassTypeAttribute : Attribute
    {
        public readonly string TypeString;

        public JassTypeAttribute(string typeString)
        {
            TypeString = typeString;
        }
    }
}