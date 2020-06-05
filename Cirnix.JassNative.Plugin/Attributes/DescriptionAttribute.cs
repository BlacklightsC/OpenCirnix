using System;

namespace Cirnix.JassNative.Plugin

{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(String text)
        {
            this.Text = text;
        }

        public String Text { get; }
    }
}
