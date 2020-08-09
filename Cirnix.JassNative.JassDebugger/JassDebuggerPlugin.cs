using Cirnix.JassNative.InterfaceAPI;
using Cirnix.JassNative.JassAPI;
using Cirnix.JassNative.Plugin;
using Cirnix.JassNative.WarAPI;

namespace Cirnix.JassNative.JassDebugger
{
    [Requires(typeof(InterfaceAPIPlugin))]
	[Requires(typeof(JassAPIPlugin))]
	[Requires(typeof(WarAPIPlugin))]
	public class JassDebuggerPlugin : IPlugin
	{
		public void Initialize() { }

		public void OnGameLoad()
		{
			JassDebugger.OnGameLoad();
		}

		public void OnMapEnd() { }
		public void OnMapStart() { }
    }
}
