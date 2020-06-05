using System;

namespace Cirnix.JassNative.Plugin

{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class VersionAttribute : Attribute
    {
        private readonly String version;

        public VersionAttribute(String version)
        {
            this.version = version;
        }

        public Version Version { get { return new Version(this.version); } }
    }
}
