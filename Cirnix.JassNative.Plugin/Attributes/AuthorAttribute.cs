using System;

namespace Cirnix.JassNative.Plugin

{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class AuthorAttribute : Attribute
    {
        private readonly String name;

        public AuthorAttribute(String name)
        {
            this.name = name;
        }

        public String Name { get { return this.name; } }
    }
}
