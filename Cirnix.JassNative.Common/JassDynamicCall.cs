
using Cirnix.JassNative.JassAPI;
using Cirnix.JassNative.Plugin;

namespace Cirnix.JassNative.Common
{
    [Requires(typeof(JassAPIPlugin))]
    public class JassDynamicCall : IPlugin
    {
        public void Initialize() { }

        public void OnGameLoad()
        {

        }

        public void OnMapStart() { }

        public void OnMapEnd() { }
    }
}
