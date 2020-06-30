using Cirnix.JassNative.JassAPI;
using Cirnix.JassNative.Plugin;
using System.Diagnostics;

namespace Cirnix.JassNative.Common
{
    public class JassDebug : IPlugin
    {
        private delegate void WriteLogPrototype(JassStringArg str);
        private void WriteLog(JassStringArg str) { Trace.WriteLine(str.ToString()); }
        public void Initialize()
        {
            Natives.Add(new WriteLogPrototype(WriteLog));
        }

        public void OnGameLoad()
        {
        }

        public void OnMapEnd()
        {
        }

        public void OnMapStart()
        {
        }
    }
}
