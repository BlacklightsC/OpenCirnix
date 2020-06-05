using System;
using Cirnix.JassNative.Plugin;
using Cirnix.JassNative.JassAPI;

namespace Cirnix.JassNative.Common
{
    public sealed class JassMiscellaneous : IPlugin
    {
        private delegate JassStringRet GetDateTimePrototype();
        private JassStringRet GetDateTime()
        {
            return DateTime.Now.ToString();
        }

        public void Initialize()
        {
            Natives.Add(new GetDateTimePrototype(GetDateTime));
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