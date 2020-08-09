using System;
using System.Diagnostics;

using Cirnix.JassNative.JassAPI;
using Cirnix.JassNative.Plugin;

namespace Cirnix.JassNative.Common
{
    [Requires(typeof(JassAPIPlugin))]
    public sealed class JassMiscellaneous : IPlugin
    {
        private delegate void WriteLogPrototype(JassStringArg str);
        private void WriteLog(JassStringArg str) => Trace.WriteLine(str.ToString());

        private delegate JassStringRet GetLocalDateTimePrototype();
        private JassStringRet GetLocalDateTime() => DateTime.Now.ToString();

        public void Initialize()
        {
            Natives.Add(new WriteLogPrototype(WriteLog));
            Natives.Add(new GetLocalDateTimePrototype(GetLocalDateTime));
        }

        public void OnGameLoad() { }

        public void OnMapEnd() { }

        public void OnMapStart() { }
    }
}