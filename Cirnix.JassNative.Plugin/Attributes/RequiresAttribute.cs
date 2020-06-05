using System;

namespace Cirnix.JassNative.Plugin

{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class RequiresAttribute : Attribute
    {
        private readonly Type type;

        public RequiresAttribute(Type type)
        {
            this.type = type;
        }

        public Type Type { get { return this.type; } }
    }
}
